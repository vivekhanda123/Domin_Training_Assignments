namespace LINQ_Demo_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            //string[] names = { "Tom", "Jerry", "Micky", "Mouse", "Honey", "Bunny" };

            //// Example for Query Syntax

            //var nameContainsA = from name in names
            //                    where (name.Contains('a'))
            //                    select name;
            //Console.WriteLine("\n Name with A list");
            //foreach (var name in nameContainsA)
            //{
            //    Console.WriteLine(name);
            //}

            //// Method syntax
            //var nameContainsM = names.Where(n => n.Contains('m')).ToList();
            //Console.WriteLine("\n Names with M list");
            //foreach(var name in nameContainsM)
            //{
            //    Console.WriteLine(name);
            //}

            //OrderByDemo orderByDemo = new OrderByDemo();
            //orderByDemo.Order();

            //GroupByDemo groupByDemo = new GroupByDemo();
            //groupByDemo.GroupBy();

            JoinsDemo joinsDemo = new JoinsDemo();
            joinsDemo.Join();

            Console.ReadKey();

        }
    }
}
