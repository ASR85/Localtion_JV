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

namespace Localtion_JV.pages.customer
{
    /// <summary>
    /// Interaction logic for AddGame.xaml
    /// </summary>
    public partial class AddGame : Page
    {
        Player p;
        public AddGame(Player p)
        {
            InitializeComponent();
            this.p = p;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tb_name.Text != "" && consoleChoice.Text != "")
            {
                Videogame m = new Videogame();
                m.Name = tb_name.Text;
                m.Console = consoleChoice.Text;                
                bool info = m.GameExisted();
                if(info is false)
                {
                    m.Insert();
                }
                MessageBox.Show("le jeu a bien été ajouté", "Confirmation");
                m.GetIdVideogames();
                Copy c = new Copy();
                c.Insert(p, m);
            }
            else
            {
                MessageBox.Show("informations manquantes","Attention");
            }
        }
    }
}
