namespace Inventory.DataAccess.Migrations
{
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
        }
    }
}
