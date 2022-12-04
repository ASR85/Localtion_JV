using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.classes
{
    internal class Administrator : User
    {
        public Administrator(string username, string password) : base(username, password)
        {
            base.Username = username;
            base.Password = password;
        }
    }
}
