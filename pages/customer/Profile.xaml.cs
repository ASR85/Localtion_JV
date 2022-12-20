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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile(Player player)
        {
            InitializeComponent();
            tb_credits.Text = $"{player.Credit}";
            List<Loan> loans = Loan.GetLoansByPlayer();
            dg1.ItemsSource = loans;
            List<Booking> bookings = Booking.GetBookingByPlayer();
            dg2.ItemsSource = bookings;
            int credit = Player.GetPlayerCredit();
            lb_rd.Content = $"Vous êtes inscrit depuis le {player.RegistrationDate}";
        }
    }
}
