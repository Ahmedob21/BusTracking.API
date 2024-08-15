using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using BusTracking.Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {

        private readonly ModelContext _context;

        public AttendanceRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AttendanceChildrenBus>> GetBusWithChildrenByTeacherId(decimal teacherId)
        {
            return await _context.Children
                .Include(c => c.Bus)
                .Include(c => c.Parent)
                .Where(c => c.Bus.Teacherid == teacherId)
                .Select(c => new AttendanceChildrenBus
                {
                    Childid = c.Childid,
                    Firstname = c.Firstname,
                    Lastname = c.Lastname,
                    parentName = c.Parent.Firstname,
                    Busnumber = c.Bus.Busnumber,
                    Parentid=c.Parentid
                })
                .ToListAsync();
        }

       

        public async Task<IEnumerable<AttendanceForChild>> GetAttendanceForChild(decimal childid)
        {
            var attendances =  await _context.Attendances.Include(child => child.Child).Where(child=>child.Childid == childid).ToListAsync();

            var attendanceForChildList = attendances.Select(attendance => new AttendanceForChild
            {
                Attendanceid = attendance.Attendanceid,
                Attendancedate = attendance.Attendancedate,
                Status = attendance.Status,
                Childid = attendance.Childid,
                Firstname = attendance.Child.Firstname,
                Lastname = attendance.Child.Lastname
            }).ToList();
            return attendanceForChildList;
        }


        public async Task CreateAttendance(AttendanceSubmission submission)
        {
            // Check if the teacher exists
          

            foreach (var attendance in submission.Attendances)
            {
                // Check if the child exists
                var childExists = await _context.Children.AnyAsync(c => c.Childid == attendance.Childid);
                if (!childExists)
                {
                    throw new Exception($"Invalid child ID: {attendance.Childid}");
                }

                // Create the attendance entity
                var attendanceEntity = new Attendance
                {
                    Status = attendance.Status,
                    Childid = attendance.Childid,
                    Teacherid = submission.Teacherid,
                    Attendancedate = DateTimeOffset.Now
                };

                _context.Attendances.Add(attendanceEntity);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();
        }

        public async Task  UpdateAttendance(decimal attendanceId, UpdateAttendance updateAttendance)
        {
            try
            {
                var attendance = await _context.Attendances.FindAsync(attendanceId);

                if (attendance == null)
                {
                    throw new Exception($"Attendance record with ID {attendanceId} not found.");
                }

                attendance.Status = updateAttendance.Status;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the attendance: {ex.Message}");
            }
        }

        public async Task DeleteAttendance(decimal attendanceId)
        {
            try
            {
                var attendance = await _context.Attendances.FindAsync(attendanceId);

                if (attendance == null)
                {
                    throw new Exception($"Attendance record with ID {attendanceId} not found.");
                }

                _context.Attendances.Remove(attendance);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the attendance: {ex.Message}");
            }
        }

        public async Task<IEnumerable<AttendanceForChild>> GetChildAttendanceForParent(decimal parentId)
        {
            // Get all children associated with the parent
            var children = await _context.Children
                .Where(c => c.Parentid == parentId)
                .ToListAsync();

            // Get attendance for all these children
            var attendanceRecords = new List<AttendanceForChild>();

            foreach (var child in children)
            {
                var childAttendances = await _context.Attendances
                    .Include(att => att.Child)
                    .Where(att => att.Childid == child.Childid)
                    .ToListAsync();

                var mappedAttendances = childAttendances.Select(attendance => new AttendanceForChild
                {
                    Attendanceid = attendance.Attendanceid,
                    Attendancedate = attendance.Attendancedate,
                    Status = attendance.Status,
                    Childid = attendance.Childid,
                    Firstname = attendance.Child.Firstname,
                    Lastname = attendance.Child.Lastname
                });

                attendanceRecords.AddRange(mappedAttendances);
            }

            return attendanceRecords;
        }
    }
}
