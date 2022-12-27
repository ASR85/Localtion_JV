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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        Player p;
        public Profile(Player player)
        {
            p = player;
            InitializeComponent();
            tb_credits.Text = $"{player.Credit}";
            lb_profile.Content = $"Profil de {player.Pseudo}";
            
            lb_rd.Content = $"Vous êtes inscrit depuis le {player.RegistrationDate.ToString("dd-MM-yyyy")}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SeeLoans(p));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SeeBookings(p));
        }
    }
}
