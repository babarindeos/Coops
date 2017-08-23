using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace MainApp
{
    public static class ConnectDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = Properties.Settings.Default.FUNAAB_CTCSConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
         
        }
    }
}
