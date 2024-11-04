using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem
{
    public class OrderService
    {
        private readonly IProductService _productService;
        public OrderService(IProductService productService)
        {
            _productService = productService;
        }
        public bool PlaceOrder(string productName, int quantity)
        {
            if(_productService.CheckStock(productName) >= quantity)
            {
                _productService.UpdateStock(productName, 
                    _productService.CheckStock(productName)-quantity);
                return true;
            }
            return false;
        }
    }
}
