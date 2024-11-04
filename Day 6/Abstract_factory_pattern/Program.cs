namespace Abstract_factory_pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            IUIFactory lightfactory = new LightUIFactory();
            Client lightClient = new Client(lightfactory);
            lightClient.RenderUI();

            IUIFactory darkfactory = new DarkUIFactory();
            Client darkClient = new Client(darkfactory);
            darkClient.RenderUI();

            Console.ReadKey();
        }
    }
}
