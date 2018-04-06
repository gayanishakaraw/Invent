using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.DataAccess.Models.Inventory
{
    public class ItemStock
    {
        public int ItemStockId { get; set; }
        public int ItemId { get; set; }
        public decimal Qty { get; set; }
        public decimal MinimumQty { get; set; }
        public string Remarks { get; set; }
        public int CompanyId { get; set; }
    }
}
