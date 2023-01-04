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
    /// Interaction logic for Reservation.xaml
    /// </summary>
    public partial class Reservation : Page
    {
        Player p;
        Videogame v;
        public Reservation(Player player, Videogame videogame)
        {
            InitializeComponent();
            p = player;
            v = videogame;
            label1.Content = v.Name;
            label2.Content = v.Console;
            label3.Content = v.CreditCost;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (calendar_ld.SelectedDate.ToString() == "")
            {
                MessageBox.Show("Veullez choisir une date de location", "Attention");
            }
            else
            {
                //string ld = calendar_dob.DisplayDate.ToString("yyyy-MM-dd");
                string rd = DateTime.Now.ToString("yyyy-MM-dd");
                DateTime? dob = calendar_ld.SelectedDate;
                DateTime loanDate = (DateTime)dob;
                string ld = loanDate.ToString("yyyy-MM-dd");
                MessageBoxResult result = MessageBox.Show($"Etes vous sur de vouoir reserver pour le {ld}", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Information);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Booking booking = new Booking();
                        booking.Insert(rd, ld, p, v);
                        p.Credit -= v.CreditCost;
                        p.RemoveCreditsWhileBooking();
                        MessageBox.Show("Reservation effectuée");
                        NavigationService.Navigate(new Profile(p));
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }
    }
}
