using Localtion_JV.classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.DAO
{
    internal class UserDAO 
    {
        private string connectionString;

        public UserDAO()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Location"].ConnectionString;
        }      

        public bool Insert(User u)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.User(Username,Password) VALUES('{u.Username}', '{u.Password}')", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();                
                success = res > 0;
            }
            return success;
        }
    }
}
