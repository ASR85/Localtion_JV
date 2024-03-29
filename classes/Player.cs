﻿using Localtion_JV.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.classes
{
    public class Player : User
    {
        private int id;
        private int credit;
        //private string pseudo;
        //private string password;
        private DateTime registrationDate;
        private DateTime dateOfBirth;
        private DateTime lastAddedBonusDate;

        public Player()
        {

        }

        public Player(int id, string pseudo, string password) : base(pseudo, password)
        {
            base.Pseudo = pseudo;
            base.Password = password;
            this.id = id;
        }

        public Player(string pseudo,string password, int credit,  DateTime registrationDate, DateTime dateOfBirth) : base(pseudo,password)
        {
            this.credit = credit;           
            this.registrationDate = registrationDate;
            this.dateOfBirth = dateOfBirth;
        }
        public Player(int id,  string pseudo, string password, int credit, DateTime registrationDate, DateTime dateOfBirth, DateTime lastAddedBonusDate) : base(pseudo, password)
        {
            base.Pseudo = pseudo;
            base.Password = password;
            this.id = id;
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
        

        public bool LoanAllowed()
        {
            PlayerDAO db = new PlayerDAO();
            return db.LoanAllowed(this);
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

        
        public static Player Login(string username, string password)
        {
            PlayerDAO db = new PlayerDAO();
            return db.GetPlayerLogin(username,password);
        }


        public bool RemoveCreditsWhileBooking()
        {
            PlayerDAO db = new PlayerDAO();
            return db.RemoveCreditsWhileBooking(this);
        }

        public bool AddCreditsLocation(int credits, Player player)
        {
            PlayerDAO db = new PlayerDAO();
            return db.AddCreditsLocation(credits,player);
        }

        public override string ToString()
        {
            return $"{this.Pseudo} , {this.Password} , {this.Credit} , {this.RegistrationDate} , {this.DateOfBirth} , ";
        }

        public static List<Player> GetPlayers()
        {
            PlayerDAO db = new PlayerDAO();
            return db.GetPlayers();
        }

    }

}
