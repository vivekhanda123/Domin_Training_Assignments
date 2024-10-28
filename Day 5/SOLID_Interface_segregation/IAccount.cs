using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Interface_segregation
{
    // We Dont have to make a single interface else we have to seperatte it with different one.
    //internal interface IAccount
    //{
    //void Withdraw(decimal amount);
    //void Deposite(decimal amount);
    //void CheckBalance(int accountNumber);
    //void BuyShares(int numberOfShares);
    //void SellShares(int numberOfShares);
    //}
    public interface IBasicAccount
    {
        void Withdraw(decimal amount);
        void Deposite(decimal amount);
        void CheckBalance(int accountNumber);
    }
    public interface IInvestmentAccount : IBasicAccount
    {
        void BuyShares(int numberOfShares);
        void SellShares(int numberOfShares);
    }
}
