using System;
using System.Collections.Generic;

namespace Invent.Web.Common.Models
{
    public partial class Roles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int PermissionGroupId { get; set; }
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
    }
}
