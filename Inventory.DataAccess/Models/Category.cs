using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.DataAccess.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Remarks { get; set; }
        public string UnitOfMeasure { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
    }
}
