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
            if (tb_username.Text != "" && tb_mdp.Text != "" && calendar_dob.Text !="")
            {
                string rd = DateTime.Now.ToString("yyyy-MM-dd");
                DateTime? dob = calendar_dob.SelectedDate;
                DateTime DofB = (DateTime)dob;
                string dob2 = DofB.ToString("yyyy-MM-dd"); 
                Player u = new Player(tb_username.Text, tb_mdp.Text, 10,DateTime.Now, calendar_dob.DisplayDate);               
                u.Insert(rd,dob2);
                MessageBox.Show($"Bienvenue sur notre site {dob}", "Félicitation");
            }
            else
            {
                MessageBox.Show("informations manquantes", "Attention");
            }
        }
    }
}
