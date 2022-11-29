using Localtion_JV.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.classes
{
    internal class Booking
    {
        private DateTime bookingDate;

        public Booking()
        {

        }
        public Booking(DateTime bookingDate)
        {
            this.bookingDate = bookingDate;
        }

        public DateTime BookingDate { get; set; }

        public void Delete()
        {

        }

        public bool Insert()
        {
            BookingDAO db = new BookingDAO();
            return db.Insert(this);
        }

        public static List<Booking> GetBookingByPlayer()
        {
            BookingDAO db = new BookingDAO();
            return db.GetBookingByPlayer();
        }
    }
}
