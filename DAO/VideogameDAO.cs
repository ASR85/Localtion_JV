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
            List<Videogame> videogames = new List<Videogame>();
            try
            {
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
                            videogames.Add(videogame);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }
            return videogames;
        }

        public Copy CopyAvailable(Videogame videogame)
        {
            Copy copy = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Copies WHERE idGame = @videogameid ", connection);
                    cmd.Parameters.AddWithValue("@videogameid", videogame.Id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        copy = new Copy(
                        reader.GetInt32("id"),
                        VideogameDAO.Find(reader.GetInt32("idGame")),
                        PlayerDAO.Find(reader.GetInt32("idPlayer")),
                        Boolean.Parse(reader.GetString("available"))
                        );
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }
            return copy;
        }

        public void SelectBooking(Videogame videogame)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Bookings WHERE idGame = @videogameid", connection);
                    cmd.Parameters.AddWithValue("@videogameid", videogame.Id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }
        }

        public List<Videogame> GetAllVideogames()
        {
            List<Videogame> videogames = new List<Videogame>();
            try
            {
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
                            videogames.Add(videogame);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }
            return videogames;
        }

        public List<Videogame> GetSubmittedVideogames()
        {
            List<Videogame> videogames = new List<Videogame>();
            try
            {
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
                            videogames.Add(videogame);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }
            return videogames;
        }

        public Videogame GetIdVideogames(Videogame vg)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT id FROM dbo.VideoGames WHERE name = @vgname and console = @vgconsole", connection);
                    cmd.Parameters.AddWithValue("@vgname", vg.Name);
                    cmd.Parameters.AddWithValue("@vgconsole", vg.Console);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vg.Id = reader.GetInt32("Id");
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }
            return vg;
        }

        public bool GameExisted(Videogame vg)
        {
            bool exist = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT id FROM dbo.VideoGames WHERE name = @vgname and console = @vgconsole", connection);
                    cmd.Parameters.AddWithValue("@vgname", vg.Name);
                    cmd.Parameters.AddWithValue("@vgconsole", vg.Console);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exist = true;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }
            return exist;
        }

        public bool Insert(Videogame vg)
        {
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.VideoGames(Name,CreditCost,Console) VALUES( @vgname, 0 , @vgconsole)", connection);
                    cmd.Parameters.AddWithValue("@vgname", vg.Name);
                    cmd.Parameters.AddWithValue("@vgconsole", vg.Console);
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

        public bool UpdateCredits(int id, int credits)
        {
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"UPDATE dbo.VideoGames SET creditCost = {credits} WHERE id = {id}", connection);

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

        public bool Delete(int id)
        {
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.VideoGames WHERE Id = @id", connection);
                    cmd.Parameters.AddWithValue("@id", id);
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
