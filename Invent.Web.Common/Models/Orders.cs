using System;
using System.Collections.Generic;

namespace Invent.Web.Common.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Payments = new HashSet<Payments>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public decimal TotalAmount { get; set; }
        public string Remarks { get; set; }
        public int CompanyId { get; set; }

        public ICollection<Payments> Payments { get; set; }
    }
}
