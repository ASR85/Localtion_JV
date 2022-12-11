using Localtion_JV.DAO;
using System;
using System.Collections.Generic;
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

        public int Credit { get; set; }
        public string Pseudo { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Password { get; set; }

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
