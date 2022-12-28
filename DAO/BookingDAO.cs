using Localtion_JV.classes;
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Bookings WHERE IdPlayer ={player.Id} ", connection);
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
            return bookings;
        }

        public bool Insert(string bd, string ld, Player player, Videogame videogame)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Bookings(bookingDate,loanDate,idPlayer,idGame) VALUES('{bd}','{ld}',{player.Id}, {videogame.Id} )", connection);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public bool Delete(Booking b)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Bookings WHERE id= {b.Id}", connection);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
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

                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Bookings WHERE idPlayer = " + player);
                    cmd.Parameters.AddWithValue("idPlayer", player);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Booking booking = new Booking(
                                
                                PlayerDAO.Find(reader.GetInt32("idPlayer")),
                                VideogameDAO.Find(reader.GetInt32("idGame")),
                                reader.GetDateTime("bookingDate"));
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

    }
    
}
