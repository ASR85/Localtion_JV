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
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public bool Ongoing
        {
            get { return ongoing; }
            set { ongoing = value; }
        }

        public void CalculateBalance()
        {
            LoanDAO db = new LoanDAO();
            db.CalculateBalance(this);
        }

        public void EndLoan()
        {
            LoanDAO db = new LoanDAO();
             db.EndLoan(this);
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
