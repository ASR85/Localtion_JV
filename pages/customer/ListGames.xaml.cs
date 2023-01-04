using Localtion_JV.classes;
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
    /// Interaction logic for ListGames.xaml
    /// </summary>
    public partial class ListGames : Page
    {
        Player p;
        public ListGames(Player player)
        {
            InitializeComponent();
            List<Videogame> videogames = Videogame.GetVideogames();
            dg.ItemsSource = videogames;
            p = player;
            //List<Copy> copies = Copy.GetCopies(p);
            //dg.ItemsSource = copies;
        }

        private void GoToReservation(object sender, RoutedEventArgs e)
        {
            List<Booking> bookings = Booking.GetBookingByPlayer(p);
            List<Loan> loans = Loan.GetLoansByPlayer(p);
            bool alreadyLoan = false;


            if (p.LoanAllowed())
            {
                Videogame videogame = dg.SelectedItem as Videogame;
                for (int i = 0; i < bookings.Count; i++)
                {
                    Booking booking = bookings[i];
                    if (videogame.Id == booking.Videogame.Id)
                    {
                        alreadyLoan = true;
                    }

                }
                for (int j = 0; j < loans.Count; j++)
                {
                    Loan loan = loans[j];
                    if (videogame.Id == loan.Copy.Videogame.Id)
                    {
                        alreadyLoan = true;
                    }
                }

                if (alreadyLoan)
                {
                    MessageBox.Show("Le jeu est déjà en cours de réservation ou de location");
                }
                else
                {
                    NavigationService.Navigate(new Reservation(p, videogame));

                }
            }
            else
            {
                MessageBox.Show("Vous n'avez plus de crédit pour reserver un jeu");
            }
        }
    }
}
