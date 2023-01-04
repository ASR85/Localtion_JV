using Localtion_JV.classes;
using Localtion_JV.DAO;
using Localtion_JV.pages.admin;
using Localtion_JV.pages.customer;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

namespace Localtion_JV
{
    /// <summary>
    /// Interaction logic for Connection.xaml
    /// </summary>
    public partial class Connection : Page
    {
        public Connection()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String login = nomTextBox.Text;
            String password = mdpTextBox.Text;
            switch (ConnexionChoice.Text)
            {
                case "Membre":
                    Player player = Player.Login(login, password);
                    if (player == null)
                    {
                        MessageBox.Show("Erreur identifiants manquants ou incorrectes");
                    }
                    else
                    {
                        WindowClient windowClient = new WindowClient(player);
                        windowClient.Show();
                        var main = Window.GetWindow(this);
                        main.Close();
                    }
                     
                    break;
               

                case "Responsable":
                    Administrator administrator = Administrator.Login(login, password);
                    if (administrator == null)
                    {
                        MessageBox.Show("Erreur identifiants manquants ou incorrectes");
                    }
                    else
                    {
                        WindowAdmin windowAdmin = new WindowAdmin();
                        windowAdmin.Show();
                        var main = Window.GetWindow(this);
                        main.Close();
                    }
                    break;
            }           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            nomTextBox.Text = "";
            mdpTextBox.Text = "";
        }
    }
}
