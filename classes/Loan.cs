using Localtion_JV.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localtion_JV.classes
{
    internal class Loan
    {
        private DateTime startDate;
        private DateTime endDate;
        private bool ongoing;

        public Loan()
        {

        }

        public Loan(DateTime startDate, DateTime endDate, bool ongoing)
        {
            this.startDate = startDate;
            this.endDate = endDate; 
            this.ongoing = ongoing;
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Ongoing { get; set; }

        public void CalculateBalance()
        {

        }

        public void EndLoan()
        {

        }

        public bool Insert()
        {
            LoanDAO db = new LoanDAO();
            return db.Insert(this);
        }
        public static List<Loan> GetLoansByPlayer()
        {
            LoanDAO db = new LoanDAO();
            return db.GetLoansByPlayer();
        }
    }
}
