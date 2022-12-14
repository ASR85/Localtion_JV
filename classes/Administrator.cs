using Localtion_JV.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.classes
{
    internal class Administrator : User
    {
        public Administrator()
        {
        }


        public Administrator(string username, string password) : base(id, username, password)
        {
            base.Id = Id;
            base.Username = username;
            base.Password = password;
        }

        public static Administrator GetAdministrator(string pseudo, string password)
        {
            AdministratorDAO db = new AdministratorDAO();
            return db.GetAdmin(pseudo, password);
        }
    }
}
