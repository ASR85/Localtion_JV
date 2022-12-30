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
        private bool available;

        public Copy()
        {

        }

        public Copy(Videogame videogame, Player player)
        {
            this.videogame = videogame;
            this.player = player;
        }

        public Copy(int id, Videogame videogame, Player player, bool available)
        {
            this.id = id;
            this.videogame = videogame;
            this.player = player;
            this.available = available;
        }

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


        public bool Available
        {
            get { return available; }
            set { available = value; }
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

        public bool IsAvailable(Copy copy)
        {
            CopyDAO db = new CopyDAO();
            return db.IsAvailable(copy);
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

        public static List<Copy> GetCopies(Player player)
        {
            CopyDAO db = new CopyDAO();
            return db.GetCopies(player);
        }

        public static Copy FindCopiesByGame(int id)
        {
            CopyDAO db = new CopyDAO();
            return db.FindCopiesByGame(id);
        }

        public bool NoLongerAvailable()
        {
            CopyDAO db = new CopyDAO();
            return db.NoLongerAvailable(this);
        }
    }
}
