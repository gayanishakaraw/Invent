using System;
using System.Collections.Generic;

namespace Invent.Web.Common.Models
{
    public partial class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public double Qty { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        public string Remarks { get; set; }
        public int CompanyId { get; set; }
        public bool IsVoid { get; set; }
    }
}
