using Localtion_JV.classes;
using Localtion_JV.pages.admin;
using Localtion_JV.pages.customer;
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
using System.Windows.Shapes;

namespace Localtion_JV
{
    /// <summary>
    /// Interaction logic for WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window
    {
        public WindowAdmin()
        {
            InitializeComponent();
            Main.Content = new AccueilAdmin();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ListAllGames();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddSubmittedGame();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Content = new EditGame();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Etes vous sur de vouloir vous déconnectez", "Avertissement", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }           
        }
    }
}
