using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.UI.Models
{
    public class InvoiceData
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public List<DataAccess.Models.Item> Items { get; set; }
        public List<DataAccess.Models.Payment> Payments { get; set; }
    }
}
