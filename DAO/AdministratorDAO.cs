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
        public override bool Create(Administrator obj)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Administrator obj)
        {
            throw new NotImplementedException();
        }

        public override List<Administrator> DisplayAll()
        {
            throw new NotImplementedException();
        }

        public override Administrator Find(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Administrator obj)
        {
            throw new NotImplementedException();
        }

        public Administrator GetAdmin(string pseudo, string password)
        {
            Administrator admin = new Administrator();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Administrator WHERE Pseudo = '{pseudo}' and Password = '{password}'", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        admin.Username = reader.GetString("Pseudo");
                        admin.Password = reader.GetString("Password");

                    }
                }
            }
            return admin;
        }
    }
}
