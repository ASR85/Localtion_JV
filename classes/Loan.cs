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
        private int id;
        private DateTime startDate;
        private DateTime endDate;
        private bool ongoing;
        private Player borrower;
        private Player lender;
        private Copy copy;

        public Loan()
        {

        }

        public Loan(DateTime startDate, DateTime endDate, bool ongoing)
        {
            this.startDate = startDate;
            this.endDate = endDate; 
            this.ongoing = ongoing;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
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

        public Player Borrower
        {
            get { return borrower; }
            set { borrower = value; }
        }

        public Player Lender
        {
            get { return lender; }
            set { lender = value; }
        }

        public Copy Copy
        {
            get { return copy; }
            set { copy = value; }
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

        public bool Insert(Copy copy, Player player, Booking booking)
        {
            LoanDAO db = new LoanDAO();
            return db.Insert(copy,player,booking);
        }
        public static List<Loan> GetLoansByPlayer(Player player)
        {
            LoanDAO db = new LoanDAO();
            return db.GetLoansByPlayer(player);
        }
    }
}
