using Localtion_JV.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.DAO
{
    internal class AdministratorDAO : DAO<Administrator>
    {      
        public Administrator GetAdmin(string pseudo, string password)
        {
            Administrator admin = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Administrators WHERE Pseudo = @pseudo and Password = @password", connection);
                cmd.Parameters.AddWithValue("@pseudo", pseudo);
                cmd.Parameters.AddWithValue("@password", password);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        admin = new Administrator(
                        reader.GetString("Pseudo"), 
                        reader.GetString("Password")
                        );

                    }
                }
            }
            return admin;
        }
    }
}
