using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo_1
{
    internal class OfTypeOperatorDemo
    {
        public class Student
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
        }
        public void ofTypeDemo()
        {
            IList mixedList = new ArrayList();
            mixedList.Add(1);
            mixedList.Add(4500);
            mixedList.Add("Hexaware");
            mixedList.Add(new Student() { StudentId = 1, Name = "Anita" });
            mixedList.Add(new Student() { StudentId = 2, Name = "Ajay" });

            var stringResult = from m in mixedList.OfType<string>()
                               select m;

            var intResult = from m in mixedList.OfType<int>()
                            select m;

            var studentResult = from m in mixedList.OfType<Student>()
                                select m;

            Console.WriteLine("\n String type from mixed list\n ---------------------");
            foreach(var item in stringResult)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n Int type from mixed list\n ---------------------");
            foreach (var item in intResult)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n Student type from mixed list\n ---------------------");
            foreach (var item in studentResult)
            {
                Console.WriteLine($"{item.StudentId} {item.Name}");
            }
        }
    }
}
