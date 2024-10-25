using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Demo_1
{
    internal class GroupByDemo
    {
        public void GroupBy()
        {
            // Create a list of Student objects
            IList<Student> studentList = new List<Student>()
            {
                new Student() { StudentId = 1, Name = "Gem", Age = 18 },
                new Student() { StudentId = 2, Name = "Julie", Age = 15 },
                new Student() { StudentId = 3, Name = "Harsh", Age = 25 },
                new Student() { StudentId = 4, Name = "Raj", Age = 20 },
                new Student() { StudentId = 5, Name = "Raju", Age = 19 }
            };

            // Query Syntax
            var groupedQueryResult = from s in studentList
                                     group s by s.Age;

            // Method Syntax
            var groupedMethodResult = studentList.GroupBy(s => s.Age); // Deferred Execution

            var groupLookupResult = studentList.ToLookup(s => s.Age); // Immediate Execution

            // Display results for Method Syntax
            Console.WriteLine("Group by Method Syntax");
            foreach (var ageGroup in groupedMethodResult)
            {
                Console.WriteLine($"\nAge Group: {ageGroup.Key}");
                foreach (Student student in ageGroup)
                    Console.WriteLine($"{student.StudentId} {student.Name} {student.Age}");
            }

        }
    }
}
