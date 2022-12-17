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
        Videogame v;
        public DeleteGame(Videogame videogame)
        {
            v = videogame;
            InitializeComponent();
            label.Content = videogame.Name;
            List<Videogame> videogames = Videogame.GetAllVideogames();
            foreach (Videogame v in videogames)
            {
                cb_name.Items.Add(new { Text = v.Name, Value = v.Id });
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vg = (int)cb_name.SelectedValue;

            MessageBoxResult result = MessageBox.Show("Etes vous sur de vouoir le supprimer", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Information);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Videogame videogame = new Videogame();
                    videogame.Delete(vg);
                    MessageBox.Show("Suppression effectuée");
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
