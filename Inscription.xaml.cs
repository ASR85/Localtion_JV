using Localtion_JV.classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            bool alreadyExist = false;
            List<Player> players = Player.GetPlayers();
            for (int j = 0; j < players.Count; j++)
            {
                Player player = players[j];
                if(player.Pseudo == tb_username.Text)
                {
                    alreadyExist = true;
                }
            }
                if (tb_username.Text != "" && tb_mdp.Text != "" && calendar_dob.Text !="")
            {
                if (tb_username.Text.Length <= 16)
                {

                    if (alreadyExist)
                    {
                        MessageBox.Show("Vous êtes déjà enregistré!", "Attention");
                        tb_username.Text = "";
                        tb_mdp.Text = "";
                        calendar_dob.Text = "";                       
                    }
                    else
                    {
                        string rd = DateTime.Now.ToString("yyyy-MM-dd");
                        DateTime? dob = calendar_dob.SelectedDate;
                        DateTime DofB = (DateTime)dob;
                        string dob2 = DofB.ToString("yyyy-MM-dd");
                        Player u = new Player(tb_username.Text, tb_mdp.Text, 10, DateTime.Now, calendar_dob.DisplayDate);
                        u.Insert(rd, dob2);
                        MessageBox.Show($"Bienvenue sur notre site {u.Pseudo}", "Félicitation");
                        NavigationService.Navigate(new Connection());
                    }



                }
                else
                {
                    MessageBox.Show("Le pseudo doit faire au maximum 16 caractères");
                }

                
            }
            else
            {
                MessageBox.Show("informations manquantes", "Attention");
            }
        }
    }
}
