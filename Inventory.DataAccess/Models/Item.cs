using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.DataAccess.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Remarks { get; set; }
        public List<int> Categories { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
    }
}
