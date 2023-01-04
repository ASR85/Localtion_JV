using Localtion_JV.classes;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
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
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Loans WHERE idBorrower =@pid and ongoing='true' ", connection);
                cmd.Parameters.AddWithValue("@pid", player.Id);
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

        public bool Insert(string start, string end, Player player, Copy copy)
        {
            
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                bool b = true;
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Loans(startDate,endDate,ongoing, idBorrower, idLender, idCopy) VALUES (@start, @end , @b, @playerid, @copypid, @copuid)", connection);
                cmd.Parameters.AddWithValue("@start",start);
                cmd.Parameters.AddWithValue("@end", end);
                cmd.Parameters.AddWithValue("@b", b);
                cmd.Parameters.AddWithValue("@playerid", player.Id);
                cmd.Parameters.AddWithValue("@copypid", copy.Player.Id);
                cmd.Parameters.AddWithValue("@copyid", copy.Id);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }

        public void CalculateBalance(Loan l)
        {
            double i;
            if (DateTime.Today > l.EndDate)
            {
                i = (DateTime.Now - l.EndDate).TotalDays;
            }
        }

        public void EndLoan(Loan l)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"UPDATE dbo.Loans SET ongoing = 'false' WHERE id = @lId", connection);
                cmd.Parameters.AddWithValue("@lId", l.Id);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
            }
        }

        public List<Loan> GetPreviousLoans(Player player)
        {
            List<Loan> loans = new List<Loan>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Loans WHERE idBorrower = @pid and ongoing='false' ", connection);
                cmd.Parameters.AddWithValue("@pid",player.Id);
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
