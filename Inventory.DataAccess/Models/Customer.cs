using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.DataAccess.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string NIC { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string LandPhone { get; set; }
        public string HandPhone { get; set; }
        public DateTime RegisteredDate { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
    }
}
