using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.DataAccess.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDateTime { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public string Remarks { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
    }
}
