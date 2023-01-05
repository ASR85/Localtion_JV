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
    internal class CopyDAO : DAO<Copy>
    {
        public bool Insert(Player p, Videogame vg)
        {
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Copies(idPlayer,idGame,available) VALUES(@pid, @vig,'true')", connection);
                    cmd.Parameters.AddWithValue("@pid", p.Id);
                    cmd.Parameters.AddWithValue("@vig", vg.Id);
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

        public bool IsAvailable(Copy c)
        {
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"UPDATE dbo.Copies SET available = 'true' WHERE id =  @cid", connection);
                    cmd.Parameters.AddWithValue("@cid", c.Id);
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

        public bool NoLongerAvailable(Copy c)
        {
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"UPDATE dbo.Copies SET available = 'false' WHERE id = @cid", connection);
                    cmd.Parameters.AddWithValue("@cid", c.Id);
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

        public void ReleaseCopy(Copy c)
        {

        }
        public void Borrow(Copy c)
        {

        }

        public bool Delete(int id)
        {
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Copies WHERE Id = @id", connection);
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

        public List<Copy> GetCopies(Player player)
        {
            List<Copy> copies = new List<Copy>();

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {

                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Copies WHERE idPlayer != @idPlayer", connection);
                    cmd.Parameters.AddWithValue("@idPlayer", player.Id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Copy copy = new Copy(
                            VideogameDAO.Find(reader.GetInt32("idGame")),
                            PlayerDAO.Find(reader.GetInt32("idPlayer"))
                            );
                            copies.Add(copy);


                        }
                    }
                }

            }
            catch (SqlException e)
            {

                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }

            return copies;
        }

        public static List<Copy> GetListCopies(Videogame videogame)
        {
            List<Copy> copies = new List<Copy>();
            string connectionString = ConfigurationManager.ConnectionStrings["Location"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Copies WHERE idGame = @idGame", connection);
                    cmd.Parameters.AddWithValue("@idGame", videogame.Id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Copy copy = new Copy(
                            VideogameDAO.Find(reader.GetInt32("idGame")),
                            PlayerDAO.Find(reader.GetInt32("idPlayer"))
                            );
                            copies.Add(copy);


                        }
                    }
                }

            }
            catch (SqlException e)
            {

                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }

            return copies;
        }

        public static Copy Find(int id)

        {
            string connectionString = ConfigurationManager.ConnectionStrings["Location"].ConnectionString;
            Copy copy = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Copies WHERE id = @id", connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
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

            }
            catch (SqlException e)
            {

                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }

            return copy;

        }

        public Copy FindCopiesByGame(int id)

        {
            Copy copy = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Copies WHERE idGame = @idGame and available = 'true' order by id desc", connection);
                    cmd.Parameters.AddWithValue("@idGame", id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
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

            }
            catch (SqlException e)
            {

                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }

            return copy;

        }



    }
}
