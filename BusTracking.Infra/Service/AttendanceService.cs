using BusTracking.Core.DTO;
using BusTracking.Core.IRepository;
using BusTracking.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task CreateAttendance(AttendanceSubmission submission)
        {
           await _attendanceRepository.CreateAttendance(submission);
        }

        public async Task DeleteAttendance(decimal attendanceId)
        {
            await _attendanceRepository.DeleteAttendance(attendanceId);
        }

        public async Task<IEnumerable<AttendanceForChild>> GetAttendanceForChild(decimal childid)
        {
            return await _attendanceRepository.GetAttendanceForChild(childid);
        }

        public async Task<IEnumerable<AttendanceChildrenBus>> GetBusWithChildrenByTeacherId(decimal teacherId)
        {
            return await _attendanceRepository.GetBusWithChildrenByTeacherId(teacherId);
        }

        public async Task UpdateAttendance(decimal attendanceId, UpdateAttendance updateAttendance)
        {
            await _attendanceRepository.UpdateAttendance(attendanceId, updateAttendance);
        }


        public async Task<IEnumerable<AttendanceForChild>> GetChildAttendanceForParent(decimal parentId)
        {
           return await _attendanceRepository.GetChildAttendanceForParent(parentId);
        }
    }
}
