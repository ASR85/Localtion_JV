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

        public Copy CopyAvailable()
        {
            Copy copy = new Copy();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Copy WHERE idGame = @id", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                }
            }
            return copy;
        }

        public void SelectBooking()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.VideoGame", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                }
            }
        }

        public List<Videogame> GetAllVideogames()
        {
            List<Videogame> movies = new List<Videogame>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.VideoGame", connection);
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

        public List<Videogame> GetSubmittedVideogames()
        {
            List<Videogame> movies = new List<Videogame>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.VideoGame WHERE CreditCost = 0", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Videogame videogame = new Videogame();
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
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.VideoGame(Name,CreditCost,Console) VALUES('{vg.Name}', 0 , '{vg.Console}')", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public bool UpdateCredits(string name, int credits)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"UPDATE dbo.VideoGame SET CreditCost = {credits} WHERE Name = '{name}'", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public bool Delete(string name)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.VideoGame WHERE Name = '{name}'", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

    }
}
