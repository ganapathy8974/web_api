using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace webapi.model
{
    public class DBConnection
    {        
        private const string connectionString= "server = localhost;userid=root;password=12345;database=company";
        static DBConnection dbConObj;

        //singleton pattern
        public static DBConnection getDBConnectionObj()
        {
            try
            {
                if (dbConObj == null)
                {
                    dbConObj = new DBConnection();
                }
                return dbConObj;
            }catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return null;
            }
        }

        public MySqlConnection getConnection()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                return con;
            }catch(Exception ex)
            {
                return null;
            }
        }
        
    }
}
