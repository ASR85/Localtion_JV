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
    /// Interaction logic for AddSubmittedGame.xaml
    /// </summary>
    public partial class AddSubmittedGame : Page
    {
        public AddSubmittedGame()
        {
            InitializeComponent();
            List<Videogame> movies = Videogame.GetSubmittedGames();
            foreach (Videogame m in movies)
            {
                cb_name.Items.Add(m.Name);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = (string)cb_name.SelectedItem;
            int c = int.Parse(tb_credits.Text);
            if (c >0 && c <= 5)
            {
                Videogame videogame = new Videogame();
                videogame.Update(name, c);
                MessageBox.Show("Le jeu a été ajouté");
            }
            else if (c > 5 || c < 0)
            {
                MessageBox.Show("Le jeu ne peut valoir qu'entre 1 et 5 crédits");
            }
        }

        private void cb_name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
