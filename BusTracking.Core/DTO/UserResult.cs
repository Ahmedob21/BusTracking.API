using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
    public class UserResult
    {
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
        public string? Rolename { get; set; }
    }
}
