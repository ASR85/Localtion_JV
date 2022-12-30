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
    /// Interaction logic for LoansHistory.xaml
    /// </summary>
    public partial class LoansHistory : Page
    {
        public LoansHistory(Player player)
        {
            InitializeComponent();
            List<Loan> loans = Loan.GetPreviousLoans(player);
            dg.ItemsSource = loans;

            string chaine = "";
            for (int i = 0; i < loans.Count - 1; i++)
            {
                chaine += loans[i].Copy.Videogame.Name;
            }

            test.Content = chaine;
        }

        private void EndLoan(object sender, RoutedEventArgs e)
        {
            Loan loan = dg.SelectedItem as Loan;
            MessageBoxResult result = MessageBox.Show($"Etes vous sur de vouoir rendre ce jeu", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Information);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Jeu rendu");
                    loan.EndLoan();
                    break;
                case MessageBoxResult.No:
                    break;
            }


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
