using Localtion_JV.classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Localtion_JV.DAO
{
    internal class VideogameDAO : DAO<Videogame>
    {
        private string connectionString;

        public VideogameDAO()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Location"].ConnectionString;
        }

        public List<Videogame> GetVideogames()
        {
            List<Videogame> movies = new List<Videogame>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.VideoGame WHERE CreditCost > 0", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Videogame videogame = new  Videogame();
                        videogame.Name = reader.GetString("Name");
                        videogame.CreditCost = reader.GetInt32("CreditCost");
                        videogame.Console = reader.GetString("Console");
                        movies.Add(videogame);
                    }
                }
            }
            return movies;
        }

        public bool Insert(Videogame vg)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.VideoGame(Name,CreditCost,Console) VALUES('{vg.Name}', {vg.CreditCost} , '{vg.Console}')", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public override bool Update(Videogame vg)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"UPDATE dbo.VideoGame SET CreditCost = {vg.CreditCost} WHERE Id = @id", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public override bool Delete(Videogame vg)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.VideoGame WHERE Id = vg.ID", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public override bool Create(Videogame obj)
        {
            throw new NotImplementedException();
        }

        

        public override Videogame Find(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Videogame> DisplayAll()
        {
            throw new NotImplementedException();
        }
    }
}
