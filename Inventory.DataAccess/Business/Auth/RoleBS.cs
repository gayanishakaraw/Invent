using Inventory.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.DataAccess.Business.Auth
{
    public class RoleBS
    {
        static AppDbContext appDb = new AppDbContext();

        public static  Role GetRoleById(int id)
        {
            return appDb.Roles.FirstOrDefault(item => item.RoleId == id);
        }

        public static  List<Role> GetAllRoles()
        {
            return appDb.Roles.ToList();
        }

        public static  bool IsActiveRole(int id)
        {
            return appDb.Roles.FirstOrDefault(item => item.RoleId == id).IsActive;
        }

        public static  Role AddRole(Role role)
        {
            if (GetRoleById(role.RoleId) != null)
            {
                EditRole(role);
                appDb.SaveChanges();

                return role;
            }
            else
            {
                var record = appDb.Roles.Add(role);
                appDb.SaveChanges();
                return record;
            }
        }

        public static  void DeleteRole(int id)
        {
            appDb.Roles.FirstOrDefault(item => item.RoleId == id).IsActive = false;
            appDb.SaveChanges();
        }
        public static  void EditRole(Role record)
        {
            var itm = appDb.Roles.FirstOrDefault(item => item.RoleId == record.RoleId);

            itm.IsActive = record.IsActive;
            itm.RoleName = record.RoleName;
            itm.PermissionGroupId = record.PermissionGroupId;
            appDb.SaveChanges();
        }

        public static  List<Role> GetAllActiveRoles()
        {
            return appDb.Roles.Where(item => item.IsActive == true).ToList();
        }

        public static  List<Role> GetAllDisabledRoles()
        {
            return appDb.Roles.Where(item => item.IsActive == false).ToList();
        }
    }
}
