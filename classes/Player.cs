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
        private int credit;
        private string pseudo;
        private string password;
        private DateTime registrationDate;
        private DateTime dateOfBirth;

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

        public bool AddBirthdayBonus(Player p)
        {
            PlayerDAO db = new PlayerDAO();
            return db.AddBirthdayBonus(this);
        }

        public bool Insert()
        {
            PlayerDAO db = new PlayerDAO();
            return db.Insert(this);
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
