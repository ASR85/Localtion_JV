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
        int id;
        private DateTime bookingDate;
        private DateTime loanDate;
        private Videogame videogame;
        private Player player;

        public Booking()
        {

        }
        public Booking(DateTime bookingDate)
        {
            this.bookingDate = bookingDate;
        }

        public Booking(int id, DateTime bookingDate, DateTime loanDate, Videogame videogame, Player player)
        {
            Id = id;
            BookingDate = bookingDate;
            LoanDate = loanDate;
            Videogame = videogame;
            Player = player;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public DateTime BookingDate
        {
            get { return bookingDate; }
            set { bookingDate = value; }
        }

        public DateTime LoanDate
        {
            get { return loanDate; }
            set { loanDate = value; }
        }

        public Videogame Videogame
        {
            get { return videogame; }
            set { videogame = value; }
        }
        public Player Player
        {
            get { return player; }
            set { player = value; }
        }


        public void Delete()
        {
            BookingDAO db = new BookingDAO();
            db.Delete(this);
        }

        public bool Insert(string bd, string ld, Player player, Videogame videogame)
        {
            BookingDAO db = new BookingDAO();
            return db.Insert(bd,ld,player, videogame);
        }

        public static List<Booking> GetBookingByPlayer()
        {
            BookingDAO db = new BookingDAO();
            return db.GetBookingByPlayer();
        }
    }
}
