using System.Net.Cache;
using System.Security.Cryptography.X509Certificates;

namespace LINQ_Demo_2
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            List<Student> Students = new List<Student>()
            {
                new Student { Name = "Vivek", Age = 13 },
                new Student { Name = "John", Age = 15 },
                new Student { Name = "Priya", Age = 14 }
            };
            //foreach (var student in Students)
            //{
            //    Console.WriteLine($"Name: {student.Name}, Age: {student.Age}");
            //}
            
            
        }
    }
}
