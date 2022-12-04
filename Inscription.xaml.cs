using Localtion_JV.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
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

namespace Localtion_JV
{
    /// <summary>
    /// Interaction logic for Inscription.xaml
    /// </summary>
    public partial class Inscription : Page
    {
        public Inscription()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {          
            NavigationService.Navigate(new Connection());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

             tb_username.Text = "";
             tb_mdp.Text = "";           

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Player u = new Player();
            u.Pseudo = tb_username.Text;
            u.Password = tb_mdp.Text;
            u.Credit = 10;
            u.RegistrationDate = DateTime.Now;
            u.DateOfBirth = calendar_dob.DisplayDate;
            u.Insert();
            MessageBox.Show($"Bienvenue sur notre site {tb_username.Text}", "Félicitation");
        }
    }
}
