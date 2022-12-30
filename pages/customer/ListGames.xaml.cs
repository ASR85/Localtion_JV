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
            List<Videogame> movies = Videogame.GetVideogames();
            dg.ItemsSource = movies;
            p = player;
            //List<Copy> copies = Copy.GetCopies(p);
            //dg.ItemsSource = copies;
        }

        private void GoToReservation(object sender, RoutedEventArgs e)
        {
            if (p.LoanAllowed())
            {
                Videogame videogame = dg.SelectedItem as Videogame;
                NavigationService.Navigate(new Reservation(p, videogame));
            }
            else
            {
                MessageBox.Show("Vous n'avez plus de crédit pour reserver un jeu");
            }
        }
    }
}
