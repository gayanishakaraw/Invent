using Inventory.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.DataAccess.Business
{
    public class CompanyBS
    {
        static AppDbContext appDb = new AppDbContext();

        public static Company GetCompanyById(int id)
        {
            return appDb.Companies.FirstOrDefault(item => item.CompanyId == id);
        }

        public static List<Company> GetAllCompanies()
        {
            return appDb.Companies.ToList();
        }

        public static bool IsActiveCompany(int id)
        {
            return appDb.Companies.FirstOrDefault(item => item.CompanyId == id).IsActive;
        }

        public static Company AddCompany(Company company)
        {
            if (GetCompanyById(company.CompanyId) != null)
            {
                EditCompany(company);
                return company;
            }
            else
            {
                return appDb.Companies.Add(company);
            }
        }

        public static void DeleteCompany(int id)
        {
            appDb.Companies.FirstOrDefault(item => item.CompanyId == id).IsActive = false;
            appDb.SaveChanges();
        }
        public static void EditCompany(Company company)
        {
            var comp = appDb.Companies.FirstOrDefault(item => item.CompanyId == company.CompanyId);

            comp.Name = company.Name;
            comp.WebAddress = company.WebAddress;
            comp.RegistrationNumber = company.RegistrationNumber;
            comp.MobilePhone = company.MobilePhone;
            comp.LogoUrl = company.LogoUrl;
            comp.LandPhone = company.LandPhone;
            comp.IsActive = company.IsActive;
            comp.Fax = company.Fax;
            comp.Email = company.Email;
            comp.AddressLine1 = company.AddressLine1;
            comp.AddressLine2 = company.AddressLine2;
            comp.AddressLine3 = company.AddressLine3;

            appDb.SaveChanges();

        }
    }
}
