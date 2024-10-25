using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo_1
{
    // Define the Student class
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int CourseId { get; set; }
    }

    internal class OrderByDemo
    {
        public void Order()
        {
            //Create a list of Student objects
            IList<Student> studentList = new List<Student>()
                {
                    new Student() { StudentId = 1, Name = "Gem", Age = 18 },
                    new Student() { StudentId = 2, Name = "Julie", Age = 15 },
                    new Student() { StudentId = 3, Name = "Harsh", Age = 25 },
                    new Student() { StudentId = 4, Name = "Raj", Age = 20 },
                    new Student() { StudentId = 5, Name = "Raju", Age = 19 }
                };

            // Query syntax for ordering students by Name (ascending and descending)
            //    var studentListNameAsc = from s in studentList
            //                             orderby s.Name
            //                             select s;

            //    var studentListNameDesc = from s in studentList
            //                              orderby s.Name descending
            //                              select s;

            //    // Method syntax for ordering students by Name (ascending and descending)
            //    var studentNameAsc1 = studentList.OrderBy(s => s.Name);
            //    var studentNameDesc1 = studentList.OrderByDescending(s => s.Name);

            //    // Display the ordered lists
            //    Console.WriteLine("Order by Ascending (Query Syntax):");
            //    foreach (var student in studentListNameAsc)
            //    {
            //        Console.WriteLine($"{student.StudentId} {student.Name} {student.Age}");
            //    }

            //    Console.WriteLine("\nOrder by Ascending (Method Syntax):");
            //    foreach (var student in studentNameAsc1)
            //    {
            //        Console.WriteLine($"{student.StudentId} {student.Name} {student.Age}");
            //    }

            //    Console.WriteLine("\nOrder by Descending (Query Syntax):");
            //    foreach (var student in studentListNameDesc)
            //    {
            //        Console.WriteLine($"{student.StudentId} {student.Name} {student.Age}");
            //    }

            //    Console.WriteLine("\nOrder by Descending (Method Syntax):");
            //    foreach (var student in studentNameDesc1)
            //    {
            //        Console.WriteLine($"{student.StudentId} {student.Name} {student.Age}");
            //    }

            // Usage of thenbydescending 
            var orderByAge1 = from s in studentList
                              orderby s.Age ascending, s.Name descending
                              select s;

            var orderByAge = studentList.OrderBy(s => s.Age).ThenByDescending(s => s.Name);

            Console.WriteLine("\n Order by Age");
            foreach(var item in orderByAge)
            {
                Console.WriteLine($"{item.StudentId}  {item.Name} {item.Age}");
            }
                              
        }

    }
}