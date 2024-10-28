using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Day_5.Interface
{
    public interface IManageBook
    {
        // For users
        void AddBook(string book);
        void RemoveBook(string book);
    }
}
