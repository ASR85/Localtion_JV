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
    /// Interaction logic for SeeLoans.xaml
    /// </summary>
    public partial class SeeLoans : Page
    {
        Player p;
        public SeeLoans(Player player)
        {
            p = player;
            int credits;
            InitializeComponent();
            List<Loan> loans = Loan.GetLoansByPlayer(player);
            dg.ItemsSource = loans;

            for(int i =0; i< loans.Count; i++)
            {
                if (loans[i].EndDate < DateTime.Now)
                {
                    credits = (int)(2 * (loans[i].EndDate.Date - DateTime.Now.Date).TotalDays);
                }
            }

        }

        private void EndLoan(object sender, RoutedEventArgs e)
        {
            int days = 0;
            int credits = 0;
            Loan loan = dg.SelectedItem as Loan;
            if (loan.EndDate < DateTime.Now)
            {
                days = (int)((DateTime.Now.Date - loan.EndDate.Date).TotalDays);
                credits = 5 *days;
                MessageBoxResult result = MessageBox.Show($"Vous avez {days} jour(s) de retard donc vous avez une pénalité de {credits} credits.", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Information);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        MessageBox.Show("Jeu rendu");
                        p.Credit -= credits;
                        p.RemoveCreditsWhileBooking();                                             
                        loan.EndLoan();
                        Copy copy = new Copy();
                        copy.IsAvailable(loan.Copy);
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Merci");
                MessageBoxResult result = MessageBox.Show($"Etes vous sur de vouoir rendre ce jeu", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Information);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        MessageBox.Show("Jeu rendu");
                        loan.EndLoan();
                        Copy copy = new Copy();
                        copy.IsAvailable(loan.Copy);
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }



        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoansHistory(p));
        }
    }
}
