using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
