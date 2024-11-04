namespace Structural_facade_design_pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Customer customer = new Customer();
            customer.CustomerId = 1;
            customer.CustomerName = "Test";
            customer.MobileNumber = "98764321";
            customer.Location = "Indore";

            CustomerRegistration registration = new CustomerRegistration();
            registration.RegisterCustomer(customer);

            Console.ReadKey();
        }
    }
}
