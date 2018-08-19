using Invent.Web.Common;
using Invent.Web.Common.Models;
using Invent.Web.DataAccess;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Invent.Web.Business.Repositories
{
    public class PermissionsBsRepository : GenericRepository<Permissions>, IPermissionsBsRepository
    {
        private readonly InventoryDbContext _dbContext;
        public PermissionsBsRepository(InventoryDbContext context)
            : base(context)
        {
            _dbContext = context;
        }

        public async Task<bool> CanProceedAsync(int userId, Modules module, Actions eventType)
        {
            bool result = false;

            bool hasFullAccess = await HasFullAccessAsync(userId, (int)module).ConfigureAwait(false);
            bool hasAccessToEdit = await HasAccessToEditAsync(userId, (int)module).ConfigureAwait(false);

            await Task.Run(() =>
            {
                switch (eventType)
                {
                    case Actions.Edit:
                        if (!hasFullAccess || !hasAccessToEdit)
                            result = true;
                        break;

                    case Actions.Read:
                        if (!hasFullAccess || !hasAccessToEdit)
                            result = true;
                        break;
                    default:
                        result = false;
                        break;
                }
            });

            return result;
        }

        public async Task<bool> HasFullAccessAsync(int userId, int moduleId)
        {
            return await Task.Run(() =>
            {
                var user = _dbContext.Users.FirstOrDefault(item => item.UserId == userId);
                int permissionGroup = _dbContext.Roles.FirstOrDefault(item => item.RoleId == user.RoleId).PermissionGroupId;
                var permissions = _dbContext.Permissions.Where(item => item.PermissionGroupId == permissionGroup);

                var setting = permissions.FirstOrDefault(item => item.ModuleId == moduleId);

                if (setting != null)
                    return setting.FullAccess;
                else
                    return false;
            });
        }

        private async Task<bool> HasAccessToReadAsync(int userId, int moduleId)
        {
            return await Task.Run(() =>
            {
                var user = _dbContext.Users.FirstOrDefault(item => item.UserId == userId);
                int permissionGroup = _dbContext.Roles.FirstOrDefault(item => item.RoleId == user.RoleId).PermissionGroupId;
                var permissions = _dbContext.Permissions.Where(item => item.PermissionGroupId == permissionGroup);

                var setting = permissions.FirstOrDefault(item => item.ModuleId == moduleId);

                if (setting != null)
                    return setting.CanRead;
                else
                    return false;
            });
        }

        private async Task<bool> HasAccessToEditAsync(int userId, int moduleId)
        {
            return await Task.Run(() =>
            {
                var user = _dbContext.Users.FirstOrDefault(item => item.UserId == userId);
                int permissionGroup = _dbContext.Roles.FirstOrDefault(item => item.RoleId == user.RoleId).PermissionGroupId;
                var permissions = _dbContext.Permissions.Where(item => item.PermissionGroupId == permissionGroup);

                var setting = permissions.FirstOrDefault(item => item.ModuleId == moduleId);

                if (setting != null)
                    return setting.CanEdit;
                else
                    return false;
            });
        }

        private async Task<bool> HasAccessToViewAsync(int userId, int moduleId)
        {
            return await Task.Run(() =>
            {
                var user = _dbContext.Users.FirstOrDefault(item => item.UserId == userId);
                int permissionGroup = _dbContext.Roles.FirstOrDefault(item => item.RoleId == user.RoleId).PermissionGroupId;
                var permissions = _dbContext.Permissions.Where(item => item.PermissionGroupId == permissionGroup);

                var setting = permissions.FirstOrDefault(item => item.ModuleId == moduleId);

                if (setting != null)
                    return setting.CanView;
                else
                    return false;
            });
        }
    }
}
