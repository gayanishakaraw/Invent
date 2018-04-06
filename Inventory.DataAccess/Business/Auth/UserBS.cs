using Inventory.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.DataAccess.Business.Auth
{
    public class UserBS
    {
        static AppDbContext appDb = new AppDbContext();

        public static User GetUserById(int id)
        {
            return appDb.Users.FirstOrDefault(item => item.UserId == id);
        }

        public static List<User> GetAllUsers()
        {
            return appDb.Users.ToList();
        }

        public static bool IsActiveUser(int id)
        {
            return appDb.Users.FirstOrDefault(item => item.UserId == id).IsActive;
        }

        public static User AddUser(User user)
        {
            if (GetUserById(user.UserId) != null)
            {
                EditUser(user);
                return user;
            }
            else
            {
                var record = appDb.Users.Add(user);
                appDb.SaveChanges();
                return record;
            }
        }

        public static void DeleteUser(int id)
        {
            appDb.Users.FirstOrDefault(item => item.UserId == id).IsActive = false;
            appDb.SaveChanges();
        }
        public static void EditUser(User record)
        {
            var itm = appDb.Users.FirstOrDefault(item => item.UserId == record.UserId);

            itm.IsActive = record.IsActive;
            itm.LastName = record.LastName;
            itm.FirstName = record.FirstName;
            itm.Email = record.Email;
            itm.RoleId = record.RoleId;
            itm.Password = record.Password;
            appDb.SaveChanges();
        }

        public static List<User> GetAllActiveUsers()
        {
            return appDb.Users.Where(item => item.IsActive == true).ToList();
        }

        public static List<User> GetAllDisabledUsers()
        {
            return appDb.Users.Where(item => item.IsActive == false).ToList();
        }
    }
}
