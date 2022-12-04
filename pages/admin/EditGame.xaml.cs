﻿using Localtion_JV.classes;
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
            List<Videogame> movies = Videogame.GetAllVideogames();
            foreach (Videogame m in movies)
            {
                cb_name.Content = m.Name + " " + m.CreditCost + " " + m.Console;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Videogame m = new Videogame();
            m.CreditCost = int.Parse(tb_credit.Text);
            m.Update();
        }
    }
}
