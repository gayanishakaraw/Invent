using System;
using System.Collections.Generic;

namespace Invent.Web.Common.Models
{
    public partial class ItemStocks
    {
        public int ItemStockId { get; set; }
        public int ItemId { get; set; }
        public decimal Qty { get; set; }
        public decimal MinimumQty { get; set; }
        public string Remarks { get; set; }
        public int CompanyId { get; set; }
    }
}
