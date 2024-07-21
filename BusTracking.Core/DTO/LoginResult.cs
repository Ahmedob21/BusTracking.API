using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
    public class LoginResult
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Token { get; set; }
    }
}
