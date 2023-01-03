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
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.VideoGames WHERE CreditCost > 0", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Videogame videogame = new Videogame();
                        videogame.Id = reader.GetInt32("Id");
                        videogame.Name = reader.GetString("Name");
                        videogame.CreditCost = reader.GetInt32("CreditCost");
                        videogame.Console = reader.GetString("Console");
                        movies.Add(videogame);
                    }
                }
            }
            return movies;
        }

        public Copy CopyAvailable(Videogame videogame)
        {
            Copy copy = new Copy();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Copies WHERE idGame = {videogame.Id} ", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                }
            }
            return copy;
        }

        public void SelectBooking(Videogame videogame)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Bookings WHERE idGame = {videogame.Id}", connection);
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.VideoGames", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Videogame videogame = new Videogame();
                        videogame.Id = reader.GetInt32("Id");
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.VideoGames WHERE CreditCost = 0", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Videogame videogame = new Videogame();
                        videogame.Id = reader.GetInt32("Id");
                        videogame.Name = reader.GetString("Name");
                        videogame.CreditCost = reader.GetInt32("CreditCost");
                        videogame.Console = reader.GetString("Console");
                        movies.Add(videogame);
                    }
                }
            }
            return movies;
        }

        public Videogame GetIdVideogames(Videogame vg)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT id FROM dbo.VideoGames WHERE name = '{vg.Name}' and console = '{vg.Console}'", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vg.Id = reader.GetInt32("Id");
                    }
                }
            }
            return vg;
        }

        public bool GameExisted(Videogame vg)
        {
            bool exist = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT id FROM dbo.VideoGames WHERE name = '{vg.Name}' and console = '{vg.Console}'", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exist = true;
                    }
                }
            }
            return exist;
        }

        public bool Insert(Videogame vg)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.VideoGames(Name,CreditCost,Console) VALUES('{vg.Name}', 0 , '{vg.Console}')", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public bool UpdateCredits(int id, int credits)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"UPDATE dbo.VideoGames SET creditCost = {credits} WHERE id = {id}", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public bool Delete(int id)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.VideoGames WHERE Id = {id}", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public Videogame FindGame(int id)
        {
            Videogame videogame = null;
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.VideoGames WHERE Id = {id}", connection);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        videogame = new Videogame(
                        reader.GetInt32("id"),
                        reader.GetString("name"),
                        reader.GetInt32("creditCost"),
                        reader.GetString("console"));

                    }
                }
            }
            return videogame;
        }

        public static Videogame Find(int id)

        {
            string connectionString = ConfigurationManager.ConnectionStrings["Location"].ConnectionString;
            Videogame videoGame = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.VideoGames WHERE id = @id", connection);
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            videoGame = new Videogame(
                            reader.GetInt32("id"),
                            reader.GetString("name"),
                            reader.GetInt32("creditCost"),
                            reader.GetString("console"));

                        }
                    }
                }

            }
            catch (SqlException e)
            {

                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }

            return videoGame;

        }

    }
}
