using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Localtion_JV.classes;

namespace Localtion_JV
{
    /// <summary>
    /// Interaction logic for Accueil.xaml
    /// </summary>
    public partial class Accueil : Page
    {

        public System.Windows.Media.ImageSource Icon { get; set; }

        public Accueil()
        {
             
            InitializeComponent();
            List<Player> players = Player.GetPlayers();
            for(int j = 0; j < players.Count; j++)
            {
                Player player = players[j];
                int credit;
                List<Booking> bookings = Booking.GetBookingByPlayer(player);

                for (int i = 0; i < bookings.Count; i++)
                {
                    Booking booking = bookings[i];
                    if (booking.LoanDate <= DateTime.Today)
                    {
                        string start = booking.LoanDate.ToString("yyyy-MM-dd");
                        string end = booking.LoanDate.AddDays(7).ToString("yyyy-MM-dd");
                        Copy copy = Copy.FindCopiesByGame(booking.Videogame.Id);
                        if (copy != null)
                        {
                            //MessageBox.Show($"Votre location du jeu : {booking.Videogame.Name} a commencé");
                            Loan loan = new Loan();
                            loan.Insert(start, end, player, copy);
                            credit = copy.Player.Credit + copy.Videogame.CreditCost;
                            Player loaner = new Player();
                            loaner.AddCreditsLocation(credit, copy.Player);
                            copy.NoLongerAvailable();
                            booking.Delete();
                        }
                        else
                        {
                            //MessageBox.Show($"Le jeu {booking.Videogame.Name} n'est pas disponible votre location est repoussé à plus tard");
                            string date = DateTime.Now.ToString("yyyy-MM-dd");
                            booking.UpdateLoanDate(date);
                        }

                    }

                }
            }
        }
    }
}
