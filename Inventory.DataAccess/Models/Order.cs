using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.DataAccess.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public decimal TotalAmount { get; set; }
        public List<Payment> Payments { get; set; }
        public string Remarks { get; set; }
        public int CompanyId { get; set; }

    }
}
