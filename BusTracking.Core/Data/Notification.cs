using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data
{
    public partial class Notification
    {
        public decimal Notificationid { get; set; }
        public string? Message { get; set; }
        public DateTimeOffset? Notificationdate { get; set; }
        public decimal? ParentId { get; set; }
        public decimal? TeacherId { get; set; }

        public virtual User? Parent { get; set; }
        public virtual User? Teacher { get; set; }
    }
}
