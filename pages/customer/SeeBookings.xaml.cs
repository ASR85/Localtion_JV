using Localtion_JV.classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
       
        Player p = new Player();
        
public SeeBookings(Player player)
{
            InitializeComponent();
            string chaine = "";
            p=player;
            List<Booking> bookings = Booking.GetBookingByPlayer(p);
            dg.ItemsSource = bookings;
            foreach (var booking in bookings)
            {
                Console.WriteLine(booking);
                chaine+= booking.ToString();
            }
            Texte.Content= chaine;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

           

        }

    }
}
