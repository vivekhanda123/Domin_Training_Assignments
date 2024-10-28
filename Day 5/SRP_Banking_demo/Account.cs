using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_Banking_demo
{
    internal class Account
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public Account(int accountNumber, decimal balance = 0)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public void Deposite(decimal amount)
        {
            Console.WriteLine("\nWelcome to Deposite section!");
            Balance = Balance + amount;
        }
        public void Withdraw(decimal amount)
        {
            Console.WriteLine("\nWelcome to Withdrawal section!");
            Balance = Balance - amount;
        }
    }
}
