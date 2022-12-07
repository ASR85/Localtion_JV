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

namespace Localtion_JV.pages.customer
{
    /// <summary>
    /// Interaction logic for AccueilCustomer.xaml
    /// </summary>
    public partial class AccueilCustomer : Page
    {
        Player p;
        public AccueilCustomer(Player player)
        {
            InitializeComponent();

            p = player;

            label_accueil.Content = "Bienvenue " + player.Pseudo;
        }
    }
}
