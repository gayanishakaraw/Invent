namespace Inventory.DataAccess.Migrations
{
    using Inventory.DataAccess.Business.Auth;
    using Inventory.DataAccess.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Inventory.DataAccess.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Inventory.DataAccess.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Companies.AddOrUpdate(x => x.CompanyId,
               new Company() { Name = "SuperOrg", IsActive = true }
               );

            context.Users.AddOrUpdate(x => x.UserId,
                new User() { UserName = "SuperAdmin", Password = "1qaz!QAZ", Email = "gayanishakaraw@gmail.com", FirstName = "Gayan", RoleId = 1, CompanyId = 1, IsActive = true }
                );

            context.Roles.AddOrUpdate(x => x.RoleId,
               new Role() { RoleId = 1, RoleName = "SuperAdmin", CompanyId = 1, IsActive = true }
               );

            context.PermissionGroups.AddOrUpdate(x => x.PermissionGroupId,
               new PermissionGroup() { PermissionGroupId = 1, PermissionGroupName = "SuperAdminPG", CompanyId = 1, IsActive = true }
               );

            foreach (var moduleIndex in typeof(Modules).GetEnumValues())
            {
                context.Permissions.AddOrUpdate(x => x.PermissionId,
                   new Permission() { PermissionId = (int)moduleIndex, FullAccess = true, CompanyId = 1, PermissionGroupId = 1 }
                   );
            }

            for (int i = 1; i < 5; i++)
            {
                context.Categories.AddOrUpdate(x => x.CategoryId,
                   new Category() { CategoryName = string.Format("Test Gategoty {0}", i), CompanyId = 1, IsActive = true }
                   );
            }

            int categoryOffset = 5;
            int currentCategory = 1;

            for (int i = 1; i < 50; i++)
            {
                if (i <= categoryOffset)
                {
                    context.Items.AddOrUpdate(x => x.ItemId,
                       new Item() { ItemName = string.Format("Test Item {0}", i), CategoryId = currentCategory, CompanyId = 1, Price = new Random().Next(10, 30000), IsActive = true }
                       );
                }
                else
                {
                    currentCategory++;
                    categoryOffset = categoryOffset + i;
                }
            }

            for (int i = 1; i < 15; i++)
            {
                context.Customers.AddOrUpdate(x => x.CustomerId,
                   new Customer() { CustomerName = string.Format("Test Customer {0}", i), Email = string.Format("testcustomer{0}@email.com", i), LandPhone = new Random().Next(1000000, 2000000).ToString(), HandPhone = new Random().Next(1000000, 2000000).ToString(), RegisteredDate = DateTime.Now, CompanyId = 1, IsActive = true }
                   );
            }
        }
    }
}
