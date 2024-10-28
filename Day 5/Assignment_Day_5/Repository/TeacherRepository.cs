using Assignment_Day_5.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Day_5.Repository
{
    public class TeacherRepository : IBorrowBook,IReserveBook
    {
        public void BorrowBook(string book)
        {
            Console.WriteLine($"Teacher borrows the book:{book}");
        }
        public void ReserveBook(string book)
        {
            Console.WriteLine($"Teacher reserves the book:{book}");
        }
    }
}
