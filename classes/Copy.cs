using Localtion_JV.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.classes
{
    internal class Copy
    {
        public void ReleaseCopy()
        {

        }

        public void Borrow()
        {

        }

        public bool IsAvailable()
        {
            return true;
        }

        public bool Insert()
        {
            CopyDAO db = new CopyDAO();
            return db.Insert(this);
        }
    }
}
