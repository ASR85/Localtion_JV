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
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Booking WHERE IdPlayer ={player.Id} ", connection);
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
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Booking(bookingDate,loanDate,idPlayer,idGame) VALUES('{bd}','{ld}',{player.Id}, {videogame.Id} )", connection);
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
                SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Booking WHERE id= {b.Id}", connection);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

    }
}
