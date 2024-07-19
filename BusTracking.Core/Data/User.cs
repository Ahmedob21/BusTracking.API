using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data
{
    public partial class User
    {
        public User()
        {
            Arrivals = new HashSet<Arrival>();
            Attendances = new HashSet<Attendance>();
            Children = new HashSet<Child>();
            Logins = new HashSet<Login>();
            NotificationParents = new HashSet<Notification>();
            NotificationTeachers = new HashSet<Notification>();
            Testimonials = new HashSet<Testimonial>();
            busDrivers = new HashSet<bus>();
            busTeachers = new HashSet<bus>();
        }

        public decimal Userid { get; set; }
        public string Firstname { get; set; } = null!;
        public string? Imagepath { get; set; }
        public string? Phone { get; set; }
        public decimal? Roleid { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public string Lastname { get; set; } = null!;
        public string? Address { get; set; }
        public string Username { get; set; } = null!;
        public string? Gender { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Arrival> Arrivals { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Child> Children { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Notification> NotificationParents { get; set; }
        public virtual ICollection<Notification> NotificationTeachers { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
        public virtual ICollection<bus> busDrivers { get; set; }
        public virtual ICollection<bus> busTeachers { get; set; }
    }
}
