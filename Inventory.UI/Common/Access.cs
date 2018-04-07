using Inventory.DataAccess.Business.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory.UI.Common
{
    public class Access
    {
        private static Access _instance;

        public static Access Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Access();

                return _instance;
            }
        }

        private Access()
        {
        }

        public bool CanProceed(Modules module, Actions eventType)
        {
            bool result = false;

            switch (eventType)
            {
                case Actions.Edit:
                    if (!PermissionBS.HasFullAccess(Session.Instance.AuthUser.UserId, (int)module) ||
                        !PermissionBS.HasAccessToEdit(Session.Instance.AuthUser.UserId, (int)module))
                    {
                        MessageBox.Show("User doesn't have access to edit this module.");
                        result = false;
                    }
                    else
                        result = true;
                    break;

                case Actions.Read:
                    if (!PermissionBS.HasFullAccess(Session.Instance.AuthUser.UserId, (int)module) ||
                        !PermissionBS.HasAccessToRead(Session.Instance.AuthUser.UserId, (int)module))
                    {
                        MessageBox.Show("User doesn't have access to view this module.");
                        result = false;
                    }
                    else
                        result = true;
                    break;

            }

            return result;
        }

    }
}
