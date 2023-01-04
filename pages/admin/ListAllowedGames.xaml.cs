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

namespace Localtion_JV.pages.admin
{
    /// <summary>
    /// Interaction logic for ListAllowedGames.xaml
    /// </summary>
    public partial class ListAllowedGames : Page
    {
        public ListAllowedGames()
        {
            InitializeComponent();
            List<Videogame> videogames = Videogame.GetVideogames();
            dg.ItemsSource = videogames;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Videogame videogame = dg.SelectedItem as Videogame;
            MessageBoxResult result = MessageBox.Show($"Etes vous sur de vouoir supprimer {videogame.Name}", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Information);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    videogame.Delete(videogame.Id);
                    MessageBox.Show("Suppression effectuée");
                    break;
                case MessageBoxResult.No:
                    break;
            }
            //NavigationService.Navigate(new DeleteGame(videogame));
        }
        private void button_Click1(object sender, RoutedEventArgs e)
        {
            Videogame videogame = dg.SelectedItem as Videogame;
            if (tb_c.Text != "")
            {
                int c = int.Parse(tb_c.Text);
                if (c > 0 && c <= 5)
                {
                    videogame.Update(videogame.Id, c);
                    NavigationService.Navigate(new ListAllowedGames());
                }
                else
                {
                    MessageBox.Show("Veullez choisir un nombre de crédits entre 1 et 5", "Attention");
                }
            }
            else
            {
                MessageBox.Show("Veullez choisir un montant pour les crédits", "Attention");
            }
        }
    }
}

