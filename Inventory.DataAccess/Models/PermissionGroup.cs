using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.DataAccess.Models
{
    public class PermissionGroup
    {
        public int PermissionGroupId { get; set; }
        public string PermissionGroupName { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
    }
}
