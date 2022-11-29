using Localtion_JV.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.classes
{
    internal class User
    {
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

        public string Username { get; set; }
        public string Password { get; set; }

        public void Login()
        {

        }

        public bool Insert()
        {
            UserDAO db = new UserDAO();
            return db.Insert(this);
        }
    }
}
