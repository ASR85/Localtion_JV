using Localtion_JV.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.classes
{
    internal class Player : User
    {
        private int credit;
        private string pseudo;
        private DateTime registrationDate;
        private DateTime dateOfBirth;

        public Player()
        {

        }

        public Player(int credit, string pseudo, DateTime registrationDate, DateTime dateOfBirth)
        {
            this.credit = credit;
            this.pseudo = pseudo;
            this.registrationDate = registrationDate;
            this.dateOfBirth = dateOfBirth;
        }

        public int Credit { get; set; }
        public string Pseudo { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool LoanAllowed()
        {
            return true;
        }

        public void AddBirthdayBonus()
        {

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

    }

}
