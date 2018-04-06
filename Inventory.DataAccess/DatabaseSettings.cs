using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DataAccess
{
    public class DatabaseSettings
    {
        public string mDatabaseServer;
        public string mDBCatalog;
        public int mPort;
        public int mTimeout;
        public string mUsername;
        private string mPassword;

        public DatabaseSettings(string databaseServer, int port, string catalog, string username, string password, int timeOut)
        {
            mDatabaseServer = databaseServer;
            mPort = port;
            mDBCatalog = catalog;
            mUsername = username;
            mPassword = password;
            mTimeout = timeOut;
        }

        public String GetConnectionString()
        {
            return string.Empty; ;
        }

        private string DecryptPassword()
        {
            return mPassword;
        }
    }

}
