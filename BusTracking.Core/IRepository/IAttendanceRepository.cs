﻿using BusTracking.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IRepository
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<AttendanceChildrenBus>> GetBusWithChildrenByTeacherId(decimal teacherId);

        Task<IEnumerable<AttendanceForChild>> GetAttendanceForChild(decimal childid);
        Task CreateAttendance(AttendanceSubmission submission);
        Task UpdateAttendance(decimal attendanceId, UpdateAttendance updateAttendance);
        Task DeleteAttendance(decimal attendanceId);
    }
}
