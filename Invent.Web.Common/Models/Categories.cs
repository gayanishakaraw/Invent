namespace Invent.Web.Common.Models
{
    public partial class Categories
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Remarks { get; set; }
        public string UnitOfMeasure { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
    }
}
