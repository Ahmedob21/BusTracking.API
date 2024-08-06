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
                    Busnumber = c.Bus.Busnumber
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



        //public async Task CreateAttendance(CreateAttendace createAttendace)
        //{

        //    var attendance = new Attendance();
        //    attendance.Status = createAttendace.Status;
        //    attendance.Childid = createAttendace.Childid;
        //    attendance.Teacherid=createAttendace.Teacherid;
        //    _context.Attendances.Add(attendance);
        //    await _context.SaveChangesAsync();
        //}


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

















    }
}
