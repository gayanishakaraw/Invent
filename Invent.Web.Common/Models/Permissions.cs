using System;
using System.Collections.Generic;

namespace Invent.Web.Common.Models
{
    public partial class Permissions
    {
        public int PermissionId { get; set; }
        public int ModuleId { get; set; }
        public bool CanRead { get; set; }
        public bool CanEdit { get; set; }
        public bool FullAccess { get; set; }
        public bool CanView { get; set; }
        public int CompanyId { get; set; }
        public int PermissionGroupId { get; set; }
    }
}
