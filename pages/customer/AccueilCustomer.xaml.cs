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
    /// Interaction logic for AccueilCustomer.xaml
    /// </summary>
    public partial class AccueilCustomer : Page
    {
        Player p;
        public AccueilCustomer(Player player)
        {
            InitializeComponent();

            p = player;
            if (DateTime.Now.ToString("yyyy-MM-dd") == p.DateOfBirth.ToString("yyyy-MM-dd") && DateTime.Now.ToString("yyyy-MM-dd") != p.LastAddedBonusDate.ToString("yyyy-MM-dd"))
            {
                label_accueil.Content = "Bon anniversaire " + player.Pseudo.ToUpper() +", pour cet evenement, on vous offre 2 crédits";
                p.Credit += 2;
                p.AddBirthdayBonus();
            }
            /*
            List<Booking> bookings = Booking.GetBookingByPlayer(p);
            foreach(Booking booking in bookings)
            {
                if (booking.LoanDate  >= DateTime.Now)
                {
                    Loan loan= new Loan();
                    //loan.Insert();
                    booking.Delete();
                }
            }*/

            
        }
    }
}
