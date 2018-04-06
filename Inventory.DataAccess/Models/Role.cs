using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.DataAccess.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int PermissionGroupId { get; set; }
        public int CompanyId { get; set; }

        public bool IsActive { get; set; }
    }
}
