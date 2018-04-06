using Inventory.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.UI
{
    public class Session
    {
        private static Session _instance;

        public static Session Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Session();

                return _instance;
            }
        }

        private Session()
        {

        }

        public AuthResponse AuthUser { get; set; }
    }
}
