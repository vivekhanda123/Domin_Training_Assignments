using Assignment_Day_5.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Day_5.Repository
{
    public class StudentRepository : IBorrowBook
    {
        public void BorrowBook(string book)
        {
            Console.WriteLine($"Student borrows the book:{book}");
        }
    }
}
