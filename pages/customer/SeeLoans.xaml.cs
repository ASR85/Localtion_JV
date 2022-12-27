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
        public SeeLoans(Player player)
        {
            InitializeComponent();
            List<Loan> loans = Loan.GetLoansByPlayer(player);
            dg.ItemsSource = loans;
        }

        private void EndLoan(object sender, RoutedEventArgs e)
        {
            Loan loan = dg.SelectedItem as Loan;
            //loan.EndLoan();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
