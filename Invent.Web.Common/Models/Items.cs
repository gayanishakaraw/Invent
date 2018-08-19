using System;
using System.Collections.Generic;

namespace Invent.Web.Common.Models
{
    public partial class Items
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Remarks { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
    }
}
