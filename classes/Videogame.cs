using Localtion_JV.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Localtion_JV.classes
{
    public class Videogame
    {
        private int id;
        private string name;
        private int creditCost;
        private string console;
        private List<Copy> copies;

        public Videogame()
        {

        }

        public Videogame(string name, int creditCost, string console)
        {
            this.name = name;
            this.creditCost = creditCost;
            this.console = console;
        }
        public Videogame(int id, string name, int creditCost, string console)
        {
            this.id = id;
            this.name = name;
            this.creditCost = creditCost;
            this.console = console;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int CreditCost
        {
            get { return creditCost; }
            set { creditCost = value; }
        }

        public string Console
        {
            get { return console; }
            set { console = value; }
        }

        public List<Copy> Copies
        {
            get { return copies; }
            set { copies = value; }
        }

        public Copy CopyAvailable()
        {
            VideogameDAO db = new VideogameDAO();
            return db.CopyAvailable(this);
        }

        public void SelectBooking()
        {
            VideogameDAO db = new VideogameDAO();
            db.SelectBooking(this);
        }

        public static List<Videogame> GetVideogames()
        {
            VideogameDAO db = new VideogameDAO();
            return db.GetVideogames();
        }
        public static List<Videogame> GetAllVideogames()
        {
            VideogameDAO db = new VideogameDAO();
            return db.GetAllVideogames();
        }

        public static List<Videogame> GetSubmittedGames()
        {
            VideogameDAO db = new VideogameDAO();
            return db.GetSubmittedVideogames();
        }

        public Videogame GetIdVideogames()
        {
            VideogameDAO db = new VideogameDAO();
            return db.GetIdVideogames(this);
        }

        public bool Insert()
        {
            VideogameDAO db = new VideogameDAO();
            return db.Insert(this);
        }
        public bool Delete(int id)
        {
            VideogameDAO db = new VideogameDAO();
            return db.Delete(id);
        }
        public bool Update(int id, int credits)
        {
            VideogameDAO db = new VideogameDAO();
            return db.UpdateCredits(id, credits);
        }

        public override string ToString()
        {
            return $"{name} sur {console} : {creditCost}";
        }

        public bool GameExisted()
        {
            VideogameDAO db = new VideogameDAO();
            return db.GameExisted(this);
        }
    }
}
