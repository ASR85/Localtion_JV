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
    /// Interaction logic for EditGame.xaml
    /// </summary>
    public partial class EditGame : Page
    {
        public EditGame()
        {
            InitializeComponent();
            List<Videogame> movies = Videogame.GetVideogames();
            foreach (Videogame m in movies)
            {
                cb_name.Items.Add(m.Name + " sur " + m.Console + " : " + m.CreditCost);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = (string)cb_name.SelectedItem;
            int credits;           
            credits = int.Parse(tb_credit.Text);
            //Videogame m = new Videogame();
            //m.Update(credits);
            if (credits > 0 && credits <= 5)
            {
                Videogame videogame = new Videogame();
                videogame.Update(name, credits);
                MessageBox.Show("Le jeu a été mis à jour");
            }
            else if (credits > 5 || credits < 0)
            {
                MessageBox.Show("Le jeu ne peut valoir qu'entre 1 et 5 crédits");
            }

        }
    }
}
