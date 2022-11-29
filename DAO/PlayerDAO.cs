using Localtion_JV.classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.DAO
{
    internal class PlayerDAO : DAO<Player>
    {
        public override bool Create(Player obj)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Player obj)
        {
            throw new NotImplementedException();
        }

        public override List<Player> DisplayAll()
        {
            throw new NotImplementedException();
        }

        public override Player Find(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Player obj)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Player pl)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Player(Credit,Pseudo,RegistrationDate,DateOfBirth) VALUES({pl.Credit}, '{pl.Pseudo}' , '{pl.RegistrationDate}', '{pl.DateOfBirth}')", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }
    }
}
