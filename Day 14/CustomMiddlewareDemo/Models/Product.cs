using System;
using System.Collections.Generic;

namespace CustomMiddlewareDemo.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? CategoryId { get; set; }
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
