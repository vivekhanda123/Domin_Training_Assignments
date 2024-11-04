using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem
{
    public interface IProductService
    {
        void AddProduct(Product product);
        bool UpdateStock(string productName, int quantity);
        int CheckStock(string productName);
    }
}
