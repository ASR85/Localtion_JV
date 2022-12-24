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
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Loan WHERE IdLender ={player.Id} ", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Loan loan = new Loan();
                        loan.StartDate = reader.GetDateTime("StartDate");
                        loan.EndDate = reader.GetDateTime("EndDate");
                        loan.Ongoing = reader.GetBoolean("Ongoing");
                        loans.Add(loan);
                    }
                }
            }
            return loans;
        }

        public bool Insert(Copy copy, Player player, Booking booking)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Loan(startDate,endDate,ongoing, idBorrower, idLender, idCopy) VALUES('{booking.BookingDate}', '{booking.BookingDate}' , true, {player.Id}, {copy.Player.Id}, {copy.Videogame.Id})", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public void CalculateBalance(Loan l)
        {

        }

        public void EndLoan(Loan l)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Loan WHERE id= {l.Id}", connection);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
            }
        }
    }
}
