﻿using System;
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
using Localtion_JV.classes;

namespace Localtion_JV
{
    /// <summary>
    /// Interaction logic for Accueil.xaml
    /// </summary>
    public partial class Accueil : Page
    {
        public Accueil()
        {
            InitializeComponent();
            List<Booking> movies = Booking.GetBookingByPlayer();
            string titles = "";
            foreach (Booking m in movies)
            {
                titles += m.BookingDate + " , ";

            }
            lb.Content = titles;
        }
    }
}
