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

        private int id;

	public int Id
	{
		get { return id;}
		set { id = value;}
	}


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
            BookingDAO db = new BookingDAO();
            db.Delete(this);
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
