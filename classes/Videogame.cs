using Localtion_JV.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Localtion_JV.classes
{
    internal class Videogame
    {
        private string name;
        private int creditCost;
        private string console;

        public Videogame()
        {

        }

        public Videogame(string name, int creditCost, string console)
        {
            this.name = name;
            this.creditCost = creditCost;   
            this.console = console;
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

        public Copy CopyAvailable()
        {
            VideogameDAO db = new VideogameDAO();
            return db.CopyAvailable();
        }

        public void SelectBooking()  
        {
            VideogameDAO db = new VideogameDAO();
            db.SelectBooking();
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

        public bool Insert()
        {
            VideogameDAO db = new VideogameDAO();
            return db.Insert(this);
        }
        public bool Update(string name, int credits)
        {
            VideogameDAO db = new VideogameDAO();
            return db.UpdateCredits(name, credits);
        }
    }
}
