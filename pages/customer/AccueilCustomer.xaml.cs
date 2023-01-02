using Localtion_JV.classes;
using Localtion_JV.DAO;
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

namespace Localtion_JV.pages.customer
{
    /// <summary>
    /// Interaction logic for AccueilCustomer.xaml
    /// </summary>
    public partial class AccueilCustomer : Page
    {
        Player p;
        public AccueilCustomer(Player player)
        {
            InitializeComponent();

            p = player;
            if (DateTime.Now.ToString("yyyy-MM-dd") == p.DateOfBirth.ToString("yyyy-MM-dd") && DateTime.Now.ToString("yyyy-MM-dd") != p.LastAddedBonusDate.ToString("yyyy-MM-dd"))
            {
                label_accueil.Content = "Bon anniversaire " + player.Pseudo.ToUpper() +", pour cet evenement, on vous offre 2 crédits";
                p.Credit += 2;
                p.AddBirthdayBonus();
            }


            int credit;
            List<Booking> bookings = Booking.GetBookingByPlayer(p);

            for(int i =0; i <bookings.Count; i++)
            {
                Booking booking = bookings[i];  
                if(booking.LoanDate <= DateTime.Today)
                {
                    string start = DateTime.Now.ToString("yyyy-MM-dd");
                    string end = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
                    Copy copy = Copy.FindCopiesByGame(booking.Videogame.Id);     
                    if(copy != null)
                    {
                        MessageBox.Show($"Votre location du jeu : {booking.Videogame.Name} a commencé");
                        Loan loan = new Loan();
                        loan.Insert(start, end, p, copy);
                        credit = copy.Player.Credit + copy.Videogame.CreditCost;
                        Player loaner = new Player();
                        loaner.AddCreditsLocation(credit, copy.Player);
                        copy.NoLongerAvailable();
                        booking.Delete();
                    }
                    else
                    {
                        MessageBox.Show($"Le jeu {booking.Videogame.Name} n'est pas disponible votre location est repoussé à plus tard");
                    }
                                 
                }
                //else
                //{
                //    MessageBox.Show("Pas Hourra");
                //}
            }

            
        }
    }
}
