using Assignment_Day_5.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Day_5.Repository
{
    public class LibrarianRepository : IManageBook,IBorrowBook,IReserveBook
    {
        public void BorrowBook(string book)
        {
            Console.WriteLine($"Librarian borrows the book:{book}");
        }

        public void ReserveBook(string book)
        {
            Console.WriteLine($"Librarian reserves the book{book}");
        }
        public void AddBook(string book)
        {
            Console.WriteLine($"Librarian adds the book{book}");
        }

        public void RemoveBook(string book)
        {
            Console.WriteLine($"Librarian removes the book{book}");
        }
    }
}
