﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
    public class UpdateAttendance
    {
        public decimal Attendanceid { get; set; }
        public string Status { get; set; } = null!;
    }
}
