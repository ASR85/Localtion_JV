using Localtion_JV.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.classes
{
    public class Player
    {
        private int id;
        private int credit;
        private string pseudo;
        private string password;
        private DateTime registrationDate;
        private DateTime dateOfBirth;
        private DateTime lastAddedBonusDate;
        private List<Booking> bookings;

        public Player()
        {

        }

        public Player(string pseudo,string password, int credit,  DateTime registrationDate, DateTime dateOfBirth)
        {
            this.pseudo = pseudo;
            this.password = password;
            this.credit = credit;           
            this.registrationDate = registrationDate;
            this.dateOfBirth = dateOfBirth;
        }
        public Player(int id,  string pseudo, string password, int credit, DateTime registrationDate, DateTime dateOfBirth, DateTime lastAddedBonusDate)
        {
            this.id = id;
            this.pseudo = pseudo;
            this.password = password;
            this.credit = credit;
            this.registrationDate = registrationDate;
            this.dateOfBirth = dateOfBirth;
            this.lastAddedBonusDate = lastAddedBonusDate;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set { registrationDate = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
        public DateTime LastAddedBonusDate
        {
            get { return lastAddedBonusDate; }
            set { lastAddedBonusDate = value; }
        }
        

        public int Credit
        {
            get { return credit; }
            set { credit = value; }
        }
        public string Pseudo
        {
            get { return pseudo; }
            set { pseudo = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public bool LoanAllowed()
        {
            return true;
        }

        public bool AddBirthdayBonus()
        {
            PlayerDAO db = new PlayerDAO();
            return db.AddBirthdayBonus(this);
        }

        public bool Insert(string rd, string dob)
        {
            PlayerDAO db = new PlayerDAO();
            return db.Insert(this, rd, dob);
        }

        public static int GetPlayerCredit()
        {
            PlayerDAO db = new PlayerDAO();
            return db.GetPlayerCredit();
        }
        
        public static Player GetPlayer(string username, string password)
        {
            PlayerDAO db = new PlayerDAO();
            return db.GetPlayerLogin(username,password);
        }

        public override string ToString()
        {
            return $"{this.Pseudo} , {this.Password} , {this.Credit} , {this.RegistrationDate} , {this.DateOfBirth} , ";
        }

    }

}
