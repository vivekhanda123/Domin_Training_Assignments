namespace SRP_Banking_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from Banking Application!");

            Statement statement = new Statement();
            statement.ShowYearlyStatement();
            statement.ShowMonthlyStatement();
            statement.ShowMiniStatement();

            Account account = new Account(123,0);
            account.Deposite(1000);
            account.Withdraw(500);
        }
    }
}
