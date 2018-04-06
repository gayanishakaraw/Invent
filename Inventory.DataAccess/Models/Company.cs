using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.DataAccess.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Email { get; set; }
        public string LandPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; }
        public string RegistrationNumber { get; set; }
        public string WebAddress { get; set; }
        public string LogoUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
