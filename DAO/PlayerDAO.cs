﻿using Localtion_JV.classes;
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
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Players(pseudo,password,credit,registrationDate,dateOfBirth) VALUES ('{pl.Pseudo}','{pl.Password}',10,'{rd}','{dob}')", connection);
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
                SqlCommand cmd = new SqlCommand($"UPDATE dbo.Players SET Credit = {p.Credit}, LastAddedBonusDate = '{date}' WHERE id={p.Id}", connection);

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
                SqlCommand cmd = new SqlCommand( $"SELECT * FROM dbo.Players WHERE Pseudo = '{login}' and Password = '{password}'", connection);
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
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Players WHERE Id ={player.Id}", connection);
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

        public Player Find(int id)
        {
            Player p = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {

                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Players WHERE id = " + @id);
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            p = new Player();
                            reader.GetInt32("id");

                            reader.GetString("pseudo");
                            reader.GetString("pasword");

                            reader.GetInt32("creditCost");
                            reader.GetString("console");

                            reader.GetDateTime("registrationDate");
                            reader.GetDateTime("dateOfBirth");
                            reader.GetDateTime("lastAddedBonusDate");

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




    }
}
