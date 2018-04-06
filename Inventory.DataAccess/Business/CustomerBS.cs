using Inventory.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.DataAccess.Business
{
    class CustomerBS
    {
        static AppDbContext appDb = new AppDbContext();

        public static Customer GetCustomerById(int id)
        {
            return appDb.Customers.FirstOrDefault(item => item.CustomerId == id);
        }

        public static List<Customer> GetAllCustomers()
        {
            return appDb.Customers.ToList();
        }

        public static bool IsActiveCustomer(int id)
        {
            return appDb.Customers.FirstOrDefault(item => item.CustomerId == id).IsActive;
        }

        public static Customer AddCustomer(Customer customer)
        {
            if (GetCustomerById(customer.CompanyId) != null)
            {
                EditCustomer(customer);
                return customer;
            }
            else
            {
                var record = appDb.Customers.Add(customer);
                appDb.SaveChanges();
                return record;
            }
        }

        public static void DeleteCustomer(int id)
        {
            appDb.Customers.FirstOrDefault(item => item.CustomerId == id).IsActive = false;
            appDb.SaveChanges();
        }
        public static void EditCustomer(Customer customer)
        {
            var cust = appDb.Customers.FirstOrDefault(item => item.CompanyId == customer.CompanyId);

            cust.CustomerName = customer.CustomerName;
            cust.Email = customer.Email;
            cust.HandPhone = customer.HandPhone;
            cust.LandPhone = customer.LandPhone;
            cust.RegisteredDate = customer.RegisteredDate;
            cust.IsActive = customer.IsActive;
            appDb.SaveChanges();
        }
    }
}
