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
    /// Interaction logic for SeeBookings.xaml
    /// </summary>
    public partial class SeeBookings : Page
    {
        public SeeBookings(Player player)
        {
            InitializeComponent();
            List<Booking> bookings = Booking.GetBookingByPlayer(player);
            dg.ItemsSource = bookings;

            if(bookings.Count == 0)
            {
                MessageBox.Show("Vous n'avez pas de réservation en cours", "Attention");
            }

            string chaine = "";
            for(int i=0; i< bookings.Count - 1;i++)
                {
                chaine += bookings[i].Videogame.Name;
                }

            test.Content = chaine;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
