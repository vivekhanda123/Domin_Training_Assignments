using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Interface_segregation
{
    internal class SavingsAccount : IBasicAccount
    {
        private decimal balance;
        public void CheckBalance(int accountNumber)
        {
            Console.WriteLine($"Current Balance = {balance}");
        }

        public void Deposite(decimal amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited amount {amount} \n Current balance {balance}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrew the amount {amount} \n Current balance {balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }
    }
}
