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
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Users(username,password) VALUES(@pseudo, @password)", connection);
                    cmd.Parameters.AddWithValue("@pseudo", u.Pseudo);
                    cmd.Parameters.AddWithValue("@password", u.Password);
                    connection.Open();
                    int res = cmd.ExecuteNonQuery();
                    success = res > 0;
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }
            return success;
        }
        public User Login(User u)
        {
            User user = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Users WHERE Pseudo = @login and Password = @password", connection);
                    cmd.Parameters.AddWithValue("@login", u.Pseudo);
                    cmd.Parameters.AddWithValue("@password", u.Password);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = new User(
                            reader.GetString("username"),
                            reader.GetString("password")
                            );
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }
            return user;
        }
    }
}
