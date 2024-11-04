namespace Adapter_design_pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            OldPaymentService oldPaymentService = new OldPaymentService();

            IPaymentProcessor paymentProcessor = new PaymentAdapter(oldPaymentService);
            Client client = new Client(paymentProcessor);
            client.MakePayment(8999.99M);
            Console.ReadKey();
        }
    }
}
