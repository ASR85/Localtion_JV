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
    /// Interaction logic for ListAllGames.xaml
    /// </summary>
    public partial class ListAllGames : Page
    {
        public ListAllGames()
        {
            InitializeComponent();
            List<Videogame> movies = Videogame.GetAllVideogames();
            dg.ItemsSource = movies;
        }
    }
}
