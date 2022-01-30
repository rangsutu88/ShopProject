using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ShopProject.DatabaseConnections
{
    class OpenDatabaseConnection
    {
        public static bool OpenConnectionWithDatabase(SqlConnection connection)
        {
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static SqlConnection GetConnection()
        {
            string ConnectionString = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = Project1Database; Integrated Security = True";
            SqlConnection connection = new SqlConnection(ConnectionString);
            return connection;
        }
    }
}
