using Localtion_JV.classes;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.DAO
{
    internal class PlayerDAO : DAO<Player>
    {
        private int credit  = 10;

        public bool Insert(Player pl, string rd, string dob)
        {           
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Players(pseudo,password,credit,registrationDate,dateOfBirth,lastAddedBonusDate) VALUES (@pseudo,@password, @credit ,@registrationDate,@dateOfBirth,@lastAddedBonusDate)", connection);
                    cmd.Parameters.AddWithValue("@pseudo", pl.Pseudo);
                    cmd.Parameters.AddWithValue("@password", pl.Password);
                    cmd.Parameters.AddWithValue("@credit", credit);
                    cmd.Parameters.AddWithValue("@registrationDate", rd);
                    cmd.Parameters.AddWithValue("@dateOfBirth", dob);
                    cmd.Parameters.AddWithValue("@lastAddedBonusDate", rd);
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


        public bool AddBirthdayBonus(Player p)
        {
            bool success = false;
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"UPDATE dbo.Players SET Credit = @pCredit, LastAddedBonusDate = @date WHERE id= @pid", connection);
                    cmd.Parameters.AddWithValue("@pCredit", p.Credit);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@pid", p.Id);
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

        public Player GetPlayerLogin(string login, string password)
        {
            Player player = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Players WHERE Pseudo = @login and Password = @password", connection);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            player = new Player(
                            reader.GetInt32("id"),
                            reader.GetString("pseudo"),
                            reader.GetString("password"),
                            reader.GetInt32("credit"),
                            reader.GetDateTime("registrationDate"),
                            reader.GetDateTime("dateOfBirth"),
                            reader.GetDateTime("lastAddedBonusDate")
                            );
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }
            return player;
        }

        public bool LoanAllowed(Player player)
        {
            int credit = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Players WHERE Id = @playerid", connection);
                    cmd.Parameters.AddWithValue("@playerid", player.Id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            credit = reader.GetInt32("Credit");
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }
            if (credit > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Player Find(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Location"].ConnectionString;
            Player p = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Players WHERE id =  @id", connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            p = new Player(
                            reader.GetInt32("id"),
                            reader.GetString("pseudo"),
                            reader.GetString("password"),
                            reader.GetInt32("credit"),
                            reader.GetDateTime("registrationDate"),
                            reader.GetDateTime("dateOfBirth"),
                            reader.GetDateTime("lastAddedBonusDate"));
                        }
                    }
                }

            }
            catch (SqlException e)
            {
                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }
            return p;
        }

        public bool RemoveCreditsWhileBooking(Player player)
        {
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"UPDATE dbo.Players SET Credit = @playercredit WHERE id= @playerid", connection);
                    cmd.Parameters.AddWithValue("@playercredit", player.Credit);
                    cmd.Parameters.AddWithValue("@playerid", player.Id);
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
        public bool AddCreditsLocation(int credits,Player player)
        {
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"UPDATE dbo.Players SET Credit = @credits WHERE id= @playerid", connection);
                    cmd.Parameters.AddWithValue("@credits", credits);
                    cmd.Parameters.AddWithValue("@playerid", player.Id);
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
    }
}
