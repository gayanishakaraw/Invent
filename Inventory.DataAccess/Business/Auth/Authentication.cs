using Inventory.DataAccess;
using Inventory.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.DataAccess.Business.Auth
{
    public class Authentication
    {

        public AuthResponse Authenticate(string username, string password)
        {
            AuthResponse result = new AuthResponse();
            result.Message = "Please provide valid credentials!";
            User attmpt = null;

            using (var context = new AppDbContext())
            {
                attmpt = context.Users.FirstOrDefault(item => item.UserName.ToLower() == username.ToLower() && item.Password == password);
            }

            if (attmpt != null)
            {
                result.Token = string.Format("{0}-{1}-{2}", DateTime.UtcNow, attmpt.UserName, "OK");
                result.UserName = attmpt.UserName;
                result.Duration = new TimeSpan(8, 0, 0);
                result.CreatedDateTime = DateTime.UtcNow;
                result.RoleId = attmpt.RoleId;
                result.CompanyId = attmpt.CompanyId;
                result.Success = true;
            }

            return result;
        }
    }
}
