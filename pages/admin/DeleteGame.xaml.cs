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
    /// Interaction logic for DeleteGame.xaml
    /// </summary>
    public partial class DeleteGame : Page
    {
        public DeleteGame()
        {
            InitializeComponent();
            List<Videogame> movies = Videogame.GetAllVideogames();
            foreach (Videogame m in movies)
            {
                cb_name.Items.Add(m.Name);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Etes vous sur de vouoir le supprimer", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Information);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Suppression effectuée");
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
