namespace Behavioral_Observer_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Stock petrolStock = new Stock("pet", 56);
            Stock bitcoinStock = new Stock("bit", 800);

            Investor investor1 = new Investor("Rahul");
            Investor investor2 = new Investor("Aditya");
            Investor investor3 = new Investor("Shaunak");

            petrolStock.Attach(investor1);
            petrolStock.Attach(investor3);

            bitcoinStock.Attach(investor1);
            bitcoinStock.Attach(investor2);
            bitcoinStock.Attach(investor3);

            petrolStock.Price = 78;
            bitcoinStock.Price = 900;

            Console.ReadKey();
        }
    }
}
