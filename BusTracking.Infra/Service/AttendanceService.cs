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

        public async Task<IEnumerable<AttendanceForChild>> GetAttendanceForChild(decimal childid)
        {
            return await _attendanceRepository.GetAttendanceForChild(childid);
        }

        public async Task<IEnumerable<AttendanceChildrenBus>> GetBusWithChildrenByTeacherId(decimal teacherId)
        {
            return await _attendanceRepository.GetBusWithChildrenByTeacherId(teacherId);
        }
    }
}
