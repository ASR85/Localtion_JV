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
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Loans WHERE IdLender =@pid ", connection);
                cmd.Parameters.AddWithValue("pid", player.Id);
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
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Loans(startDate,endDate,ongoing, idBorrower, idLender, idCopy) VALUES(@startDate, @enDate , @ongoing, @idBorrower, @idLender, @idCopy)", connection);
                cmd.Parameters.AddWithValue("@startDate", booking.BookingDate);
                cmd.Parameters.AddWithValue("@enDate", booking.BookingDate);
                cmd.Parameters.AddWithValue("@ongoing", true);
                cmd.Parameters.AddWithValue("@idBorrower", player.Id);
                cmd.Parameters.AddWithValue("@idLender", copy.Player.Id);
                cmd.Parameters.AddWithValue("@idCopy", copy.Videogame.Id);
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
                SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Loans WHERE id= @lId", connection);
                cmd.Parameters.AddWithValue("@lId", l.Id);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
            }
        }
    }
}
