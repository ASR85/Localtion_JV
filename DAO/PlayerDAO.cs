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

        public bool Insert(Player pl)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Player(pseudo,credit,registrationDate,dateOfBirth) VALUES('{pl.Pseudo}' ,{pl.Credit} , '{pl.RegistrationDate}', '{pl.DateOfBirth}'  )", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public int GetPlayerCredit()
        {
            int x = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Player WHERE Id=1", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        x = reader.GetInt32("Credit");
                    }
                }
            }
            return x;
        }

        public bool AddBirthdayBonus(Player p) {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"UPDATE dbo.Player SET Credit = {p.Credit +10} WHERE id=@id')", connection);

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
                        login,
                        password,
                        reader.GetInt32("credit"),
                        reader.GetDateTime("registrationDate"),
                        reader.GetDateTime("dateOfBirth")
                        );
                    }
                }
            }
            return player;
        }

        public bool LoanAllowed()
        {
            int credit = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Player WHERE Id =@id", connection);
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
