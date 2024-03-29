﻿using Localtion_JV.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.DAO
{
    internal class BookingDAO : DAO<Booking>
    {

        public List<Booking> GetBookingByPlayer(Player player)
        {
            List<Booking> bookings = new List<Booking>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Bookings WHERE IdPlayer = @playerid ", connection);
                    cmd.Parameters.AddWithValue("@playerid", player.Id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking booking = new Booking();
                            booking.BookingDate = reader.GetDateTime("BookingDate");
                            bookings.Add(booking);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }
            return bookings;
        }

        public bool Insert(string bd, string ld, Player player, Videogame videogame)
        {
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Bookings(bookingDate,loanDate,idPlayer,idGame) VALUES( @bd, @ld, @playerid, @videogameid )", connection);
                    cmd.Parameters.AddWithValue("@bd", bd);
                    cmd.Parameters.AddWithValue("@ld", ld);
                    cmd.Parameters.AddWithValue("@playerid", player.Id);
                    cmd.Parameters.AddWithValue("@videogameid", videogame.Id);
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

        public bool Delete(Booking b)
        {
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Bookings WHERE id= @bid", connection);
                    cmd.Parameters.AddWithValue("@bid", b.Id);
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

        public List<Booking> SeeAllBookingOfPlayer(Player player)
        {
            List<Booking> Bookingplayer = new List<Booking>();

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {

                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Bookings WHERE idPlayer = @idPlayer", connection);
                    cmd.Parameters.AddWithValue("@idPlayer", player.Id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Booking booking = new Booking(
                            reader.GetInt32("id"),
                            reader.GetDateTime("bookingDate"),
                            reader.GetDateTime("loanDate"),
                            VideogameDAO.Find(reader.GetInt32("idGame")),
                            PlayerDAO.Find(reader.GetInt32("idPlayer"))
                            );
                            Bookingplayer.Add(booking);


                        }
                    }
                }

            }
            catch (SqlException e)
            {

                throw new Exception("Erreur Sql -> " + e.Message + "!");
            }

            return Bookingplayer;
        }

        public bool UpdateLoanDate(Booking booking, string date)
        {
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"UPDATE dbo.Bookings SET loanDate = '{date}' WHERE id = {booking.Id}", connection);

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
