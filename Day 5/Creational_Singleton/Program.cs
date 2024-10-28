namespace Creational_Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var config1 = new Configuration();
            Console.WriteLine(config1.Setting);
            var config2 = new Configuration();
            Console.WriteLine(config2.Setting);
            Console.ReadKey();
        }
    }
}
