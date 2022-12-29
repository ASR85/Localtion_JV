using Localtion_JV.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.DAO
{
    internal class LoanDAO : DAO<Loan>
    {
        public List<Loan> GetLoansByPlayer(Player player)
        {
            List<Loan> loans = new List<Loan>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Loans WHERE idBorrower ={player.Id} and ongoing='true' ", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Loan loan = new Loan(
                        reader.GetInt32("Id"),
                        reader.GetDateTime("StartDate"),
                        reader.GetDateTime("EndDate"),
                        Boolean.Parse(reader.GetString("Ongoing")),
                        PlayerDAO.Find(reader.GetInt32("idBorrower")),
                        PlayerDAO.Find(reader.GetInt32("idLender")),
                        CopyDAO.Find(reader.GetInt32("idCopy"))
                        );
                        loans.Add(loan);
                    }
                }
            }
            return loans;
        }

        public bool Insert(Booking booking, Player player)
        {
            bool success = false;
            string loan = booking.LoanDate.ToString("yyyy-MM-dd");
            DateTime endloan = booking.LoanDate.AddDays(7);
            string end = endloan.ToString("yyyy-MM-dd");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Loans(startDate,endDate,ongoing, idBorrower, idLender, idCopy) VALUES('2022-12-29', '2022-12-29' , 'true', {player.Id}, {booking.Player.Id}, {booking.Videogame.Id})", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public void CalculateBalance(Loan l)
        {
            double i;
            if(DateTime.Today > l.EndDate)
            {
                i =(DateTime.Now - l.EndDate).TotalDays;              
            }
        }

        public void EndLoan(Loan l)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"UPDATE dbo.Loans SET ongoing = 'false' WHERE id = {l.Id}", connection);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
            }
        }

        public List<Loan> GetPreviousLoans(Player player)
        {
            List<Loan> loans = new List<Loan>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Loans WHERE idBorrower ={player.Id} and ongoing='false' ", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Loan loan = new Loan(
                        reader.GetInt32("Id"),
                        reader.GetDateTime("StartDate"),
                        reader.GetDateTime("EndDate"),
                        Boolean.Parse(reader.GetString("Ongoing")),
                        PlayerDAO.Find(reader.GetInt32("idBorrower")),
                        PlayerDAO.Find(reader.GetInt32("idLender")),
                        CopyDAO.Find(reader.GetInt32("idCopy"))
                        );
                        loans.Add(loan);
                    }
                }
            }
            return loans;
        }

    }
}
