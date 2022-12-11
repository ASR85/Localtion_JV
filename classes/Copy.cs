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
            CopyDAO db = new CopyDAO();
            db.ReleaseCopy(this);
        }

        public void Borrow()
        {
            CopyDAO db = new CopyDAO();
            db.Borrow(this);
        }

        public bool IsAvailable()
        {
            CopyDAO db = new CopyDAO();
            return db.IsAvailable(this);
        }

        public bool Insert()
        {
            CopyDAO db = new CopyDAO();
            return db.Insert(this);
        }
    }
}
