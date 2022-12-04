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
            switch (ConnexionChoice.Text)
            {
                case "Membre":
                    WindowClient windowClient = new WindowClient();
                    windowClient.Show();
                     
                    break;
               

                case "Responsable":
                    WindowAdmin windowAdmin = new WindowAdmin();
                    windowAdmin.Show();
                    break;
            }
            MainWindow main = Application.Current.MainWindow as MainWindow;
            if (main != null)
            {
                main.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            nomTextBox.Text = "";
            mdpTextBox.Password = "";
        }
    }
}
