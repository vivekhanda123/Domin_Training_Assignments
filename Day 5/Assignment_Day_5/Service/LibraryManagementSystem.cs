using Assignment_Day_5.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Day_5.Service
{
    public class LibraryManagementSystem
    {
        private readonly IBorrowBook _borrowBook;
        private readonly IReserveBook _reserveBook;
        private readonly IManageBook _manageBook;

        public LibraryManagementSystem(IBorrowBook borrowBook, IReserveBook reserveBook=null, IManageBook manageBook=null)
        {
            _borrowBook = borrowBook;
            _reserveBook = reserveBook;
            _manageBook = manageBook;
        }
        public void BorrowBook(string book)
        {
            _borrowBook.BorrowBook(book);
        }
        public void ReserveBook(string book)
        {
            if (_reserveBook != null)
            {
                _reserveBook.ReserveBook(book);
            }
            else
            {
                Console.WriteLine("User dont have permission to reserve book.");
            }
        }
        public void AddBook(string book)
        {
            if (_manageBook != null)
            { 
                _manageBook.AddBook(book);
            }
            else
            {
                Console.WriteLine("User dont have permission to add book.");
            }
        }
        public void RemoveBook(string book)
        {
            if (_manageBook != null)
            {
                _manageBook.RemoveBook(book);
            }
            else
            {
                Console.WriteLine("User dont have permission to remove book.");
            }
        }

    }
}
