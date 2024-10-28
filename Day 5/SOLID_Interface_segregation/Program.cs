namespace SOLID_Interface_segregation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBasicAccount basicAccount = new SavingsAccount();
            basicAccount.CheckBalance(2);
            basicAccount.Deposite(25000);
            basicAccount.Withdraw(5000);

            IInvestmentAccount investmentAccount = new InvestmentAccount();
            investmentAccount.CheckBalance(1);
            investmentAccount.Deposite(15000);
            investmentAccount.Withdraw(5000);
            investmentAccount.BuyShares(5);
            investmentAccount.SellShares(3);
           
        }
    }
}
