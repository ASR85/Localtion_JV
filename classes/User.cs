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
        private string username;
        private string password;

        public User()
        {

        }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;   
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
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
