﻿using Localtion_JV.pages.admin;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Localtion_JV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CenterWindowOnScreen();
            Main.Content = new Accueil();
        }

        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }
        private void BtnAccueil(object sender, RoutedEventArgs e)
        {
            Main.Content = new Accueil();
        }
        private void BtnInscription(object sender, RoutedEventArgs e)
        {
            Main.Content = new Inscription();
        }
        private void BtnConnection(object sender, RoutedEventArgs e)
        {
            Main.Content = new Connection();
        }
        private void BtnDetails(object sender, RoutedEventArgs e)
        {
            Main.Content = new Details();
        }
    }
}
