using Localtion_JV.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.classes
{
    public class User
    {
        private int id;
        private string pseudo;
        private string password;

        public User()
        {

        }

        public User(string pseudo, string password)
        {
            this.pseudo = pseudo;
            this.password = password;   
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
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

        public void Login(string name, string psw)
        {
            UserDAO db = new UserDAO();
            db.Login(name, psw);
        }

        public bool Insert()
        {
            UserDAO db = new UserDAO();
            return db.Insert(this);
        }
    }
}
