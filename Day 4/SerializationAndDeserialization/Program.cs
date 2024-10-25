using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SerializationAndDeserialization
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // In Json format

            //Product product = new Product() { Id = 1, Name = "Mobile", Description = "512 GB Memory", Price = 30000 };
            //string jsonString = JsonSerializer.Serialize(product);
            //Console.WriteLine($"Serialized Data \n {jsonString}");
            //File.WriteAllText("C:\\Users\\Admin\\Desktop\\Hexa Training\\Domain Specific\\Git\\Day 4\\Test.txt",jsonString);

            //string readResult = File.ReadAllText("C:\\Users\\Admin\\Desktop\\Hexa Training\\Domain Specific\\Git\\Day 4\\Test.txt");
            //Product product = JsonSerializer.Deserialize<Product>(readResult);
            //Console.WriteLine($"Id:{product.Id} \n {product.Name} \n {product.Description} \n {product.Price}");

            // In XML Format
            //Product product = new Product() { Id = 1, Name = "Mobile", Description = "512 GB Memory", Price = 30000 };
            //string filepath = "C:\\Users\\Admin\\Desktop\\Hexa Training\\Domain Specific\\Git\\Day 4\\Test.txt";
            //XmlSerializer serializer = new XmlSerializer(typeof(Product));
            //using (FileStream fs = new FileStream(filepath, FileMode.Create))
            //{
            //    serializer.Serialize(fs, product);
            //}
            //Console.WriteLine("Product Serialized to XML Format");

            // Example for Deserilize from xml to product type

            string filepath = "C:\\Users\\Admin\\Desktop\\Hexa Training\\Domain Specific\\Git\\Day 4\\Test.txt";
            XmlSerializer serializer = new XmlSerializer(typeof(Product));
            using(FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                Product product1 = (Product)serializer.Deserialize(fs);
                Console.WriteLine($"{product1.Id} \n + " +
                    $"{product1.Name} \n {product1.Description} \n {product1.Price}");
            }
            Console.ReadKey();
        }
    }
}
