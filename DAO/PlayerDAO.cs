using Localtion_JV.classes;
using System;
using System.Collections.Generic;
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

        public bool Insert(Player pl, string rd,string dob)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Player(pseudo,password,credit,registrationDate,dateOfBirth) VALUES ('{pl.Pseudo}','{pl.Password}',10,'{rd}','{dob}')", connection);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }


        public bool AddBirthdayBonus(Player p) {
            bool success = false;
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"UPDATE dbo.Player SET Credit = {p.Credit}, LastAddedBonusDate = '{date}' WHERE id={p.Id}", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public Player GetPlayerLogin(string login, string password)
        {
            Player player = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand( $"SELECT * FROM dbo.Player WHERE Pseudo = '{login}' and Password = '{password}'", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        player = new Player(
                        reader.GetInt32("id"),
                        login,
                        password,
                        reader.GetInt32("credit"),
                        reader.GetDateTime("registrationDate"),
                        reader.GetDateTime("dateOfBirth"),
                        reader.GetDateTime("lastAddedBonusDate")
                        );
                    }
                }
            }
            return player;
        }

        public bool LoanAllowed(Player player)
        {
            int credit = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Player WHERE Id ={player.Id}", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       credit = reader.GetInt32("Credit");
                    }
                }
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
    }
}
