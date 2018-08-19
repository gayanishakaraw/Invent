using System;
using System.Collections.Generic;

namespace Invent.Web.Common.Models
{
    public partial class PermissionGroups
    {
        public int PermissionGroupId { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public string PermissionGroupName { get; set; }
    }
}
