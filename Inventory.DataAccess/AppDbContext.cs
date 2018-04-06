using Inventory.DataAccess.Models;
using Inventory.DataAccess.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=AppDb")
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionGroup> PermissionGroups { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ItemStock> ItemStocks { get; set; }
    }

}
