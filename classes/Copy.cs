using Localtion_JV.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.classes
{
    public class Copy
    {
        private int id;
        private Videogame videogame;
        private Player player; 

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Videogame Videogame
        {
            get { return videogame; }
            set { videogame = value; }
        }

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }


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

        public bool Insert(Player p, Videogame vg)
        {
            CopyDAO db = new CopyDAO();
            return db.Insert(p, vg);
        }

        public bool Delete(int id)
        {
            CopyDAO db = new CopyDAO();
            return db.Delete(id);
        }
    }
}
