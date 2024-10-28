using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Interface_segregation
{
    internal class InvestmentAccount : IInvestmentAccount
    {
        private decimal balance;
        private int shares;
        public void BuyShares(int numberOfShares)
        {
            shares += numberOfShares;
            Console.WriteLine($"Bought {numberOfShares} shares \n Total Shares = {shares}");
        }

        public void SellShares(int numberOfShares)
        {
            if (numberOfShares <= shares) 
            {
                shares -= numberOfShares;
                Console.WriteLine($"Sold {numberOfShares} shares.\n Total shares{shares}");
            }
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

        public void Deposite(decimal amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited amount {amount} \n Current balance {balance}");
        }

        public void CheckBalance(int accountNumber)
        {
            Console.WriteLine($"Current Balance = {balance}");
        }
    }
}
