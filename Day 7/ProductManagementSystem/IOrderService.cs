using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem
{
    public interface IOrderService
    {
        bool PlaceOrder(string productName, int quantity);
    }
}
