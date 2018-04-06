using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.DataAccess.Models
{
    public class AuthResponse
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Message { get; set; }

        public bool Success { get; set; }
        public int RoleId { get; internal set; }
        public int CompanyId { get; internal set; }
    }
}
