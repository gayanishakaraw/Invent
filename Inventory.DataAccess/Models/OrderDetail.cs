using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.DataAccess.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public decimal Qty { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public string Remarks { get; set; }
        public int CompanyId { get; set; }
        public bool IsVoid { get; set; }
    }
}
