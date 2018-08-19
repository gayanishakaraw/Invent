using System;
using System.Collections.Generic;

namespace Invent.Web.Common.Models
{
    public partial class Customers
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string LandPhone { get; set; }
        public string HandPhone { get; set; }
        public DateTime RegisteredDate { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public string Nic { get; set; }
    }
}
