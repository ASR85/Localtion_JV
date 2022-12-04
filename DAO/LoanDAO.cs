﻿using Localtion_JV.classes;
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
        public override bool Create(Loan obj)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Loan obj)
        {
            throw new NotImplementedException();
        }

        public override List<Loan> DisplayAll()
        {
            throw new NotImplementedException();
        }

        public override Loan Find(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Loan obj)
        {
            throw new NotImplementedException();
        }

        public List<Loan> GetLoansByPlayer()
        {
            List<Loan> loans = new List<Loan>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Loan WHERE IdLender =1 ", connection);
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

        public bool Insert(Loan l)
        {
            bool success = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Loan(StartDate,EndDate,Ongoing) VALUES('{l.StartDate}', '{l.EndDate}' , '{l.Ongoing}')", connection);

                connection.Open();
                int res = cmd.ExecuteNonQuery();
                success = res > 0;
            }
            return success;
        }
    }
}
