using Localtion_JV.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.DAO
{
    internal class BookingDAO : DAO<Booking>
    {
        public override bool Create(Booking obj)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Booking obj)
        {
            throw new NotImplementedException();
        }

        public override List<Booking> DisplayAll()
        {
            throw new NotImplementedException();
        }

        public override Booking Find(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Booking obj)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetBookingByPlayer()
        {
            List<Booking> bookings = new List<Booking>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Booking WHERE IdPlayer =1 ", connection);
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

        public bool Insert(Booking b)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Booking(BookingDate) VALUES('{b.BookingDate}')", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

    }
}
