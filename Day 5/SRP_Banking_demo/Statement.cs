using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SRP_Banking_demo
{
    internal class Statement
    {
        //private List<Transaction> _transactions;
        //public Statement(List<Transaction> transactions)
        //{
        //    _transactions = transactions;
        //}
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public void ShowMiniStatement()
        {
            Console.WriteLine("\nMini Statement");
        }
        public void ShowMonthlyStatement(DateTime FromDate,DateTime ToDate)
        {
            Console.WriteLine("\nMonthly Statement");
        }
        public void ShowYearlyStatement(DateTime FromDate, DateTime ToDate)
        {
            Console.WriteLine("\nYearly Statement");
        }
    }
}
