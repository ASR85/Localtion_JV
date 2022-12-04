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

        public string Name { get; set; }
        public int CreditCost { get; set; }
        public string Console { get; set; }

        public Copy CopyAvailable()
        {
            Copy copy = new Copy();
            return copy;
        }

        public void SelectBooking()  
        {
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
        public bool Update()
        {
            VideogameDAO db = new VideogameDAO();
            return db.Update(this);
        }
    }
}
