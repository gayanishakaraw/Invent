using Inventory.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.DataAccess.Business.Auth
{
    public enum Actions
    {
        None = 0,
        Edit,
        Read,
    }

    public enum Modules
    {
        Company = 1,
        Category,
        Customer,
        Item,
        Order,
        OrderDetail,
        Payment,
        User,
        Role,
        Permission,
        Inventory
    }

    public class PermissionBS
    {
        static AppDbContext appDb = new AppDbContext();

        public static Permission GetPermissionById(int id)
        {
            return appDb.Permissions.FirstOrDefault(item => item.PermissionId == id);
        }

        public static List<Permission> GetPermissionByPermissionGroupId(int id)
        {
            return appDb.Permissions.Where(item => item.PermissionGroupId == id).ToList();
        }

        public static List<PermissionGroup> GetAllPermissionsGroups()
        {
            return appDb.PermissionGroups.ToList();
        }

        public static List<Permission> GetAllPermissions()
        {
            return appDb.Permissions.ToList();
        }

        public static PermissionGroup AddPermissionGroup(PermissionGroup permissionGroup)
        {
            if (GetPermissionById(permissionGroup.PermissionGroupId) != null)
            {
                EditPermissionGroup(permissionGroup);
                return permissionGroup;
            }
            else
            {
                var record = appDb.PermissionGroups.Add(permissionGroup);
                appDb.SaveChanges();
                return record;
            }
        }

        public static Permission AddPermission(Permission permission)
        {
            if (GetPermissionById(permission.PermissionId) != null)
            {
                EditPermission(permission);
                return permission;
            }
            else
            {
                var record = appDb.Permissions.Add(permission);
                appDb.SaveChanges();
                return record;
            }
        }

        public static void EditPermissionGroup(PermissionGroup record)
        {
            var itm = appDb.PermissionGroups.FirstOrDefault(item => item.PermissionGroupId == record.PermissionGroupId);

            itm.IsActive = record.IsActive;
            itm.PermissionGroupName = record.PermissionGroupName;

            appDb.SaveChanges();
        }

        public static void EditPermission(Permission record)
        {
            var itm = appDb.Permissions.FirstOrDefault(item => item.PermissionId == record.PermissionId);

            itm.ModuleId = record.ModuleId;
            itm.CanView = record.CanView;
            itm.CanRead = record.CanRead;
            itm.CanEdit = record.CanEdit;
            itm.FullAccess = record.FullAccess;
            appDb.SaveChanges();
        }

        public static bool HasAccessToRead(int userId, int moduleId)
        {
            var user = appDb.Users.FirstOrDefault(item => item.UserId == userId);
            int permissionGroup = appDb.Roles.FirstOrDefault(item => item.RoleId == user.RoleId).PermissionGroupId;
            var permissions = appDb.Permissions.Where(item => item.PermissionGroupId == permissionGroup);

            var setting = permissions.FirstOrDefault(item => item.ModuleId == moduleId);

            if (setting != null)
                return setting.CanRead;
            else
                return false;
        }

        public static bool HasAccessToEdit(int userId, int moduleId)
        {
            var user = appDb.Users.FirstOrDefault(item => item.UserId == userId);
            int permissionGroup = appDb.Roles.FirstOrDefault(item => item.RoleId == user.RoleId).PermissionGroupId;
            var permissions = appDb.Permissions.Where(item => item.PermissionGroupId == permissionGroup);

            var setting = permissions.FirstOrDefault(item => item.ModuleId == moduleId);

            if (setting != null)
                return setting.CanEdit;
            else
                return false;
        }

        public static bool HasAccessToView(int userId, int moduleId)
        {
            var user = appDb.Users.FirstOrDefault(item => item.UserId == userId);
            int permissionGroup = appDb.Roles.FirstOrDefault(item => item.RoleId == user.RoleId).PermissionGroupId;
            var permissions = appDb.Permissions.Where(item => item.PermissionGroupId == permissionGroup);

            var setting = permissions.FirstOrDefault(item => item.ModuleId == moduleId);

            if (setting != null)
                return setting.CanView;
            else
                return false;
        }

        public static bool HasFullAccess(int userId, int moduleId)
        {
            var user = appDb.Users.FirstOrDefault(item => item.UserId == userId);
            int permissionGroup = appDb.Roles.FirstOrDefault(item => item.RoleId == user.RoleId).PermissionGroupId;
            var permissions = appDb.Permissions.Where(item => item.PermissionGroupId == permissionGroup);

            var setting = permissions.FirstOrDefault(item => item.ModuleId == moduleId);

            if (setting != null)
                return setting.FullAccess;
            else
                return false;
        }

        public static void DeletePermissionByPermissionGroupId(int id)
        {
            var record = appDb.PermissionGroups.FirstOrDefault(item => item.PermissionGroupId == id);
            record.IsActive = false;

            var permissions = appDb.Permissions.Where(item => item.PermissionGroupId == id);
            appDb.Permissions.RemoveRange(permissions);

            appDb.SaveChanges();
        }
    }
}
