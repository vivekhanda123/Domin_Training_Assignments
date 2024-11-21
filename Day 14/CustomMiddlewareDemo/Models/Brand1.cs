using System;
using System.Collections.Generic;

namespace CustomMiddlewareDemo.Models
{
    public partial class Brand1
    {
        public Brand1()
        {
            Product1s = new HashSet<Product1>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;

        public virtual ICollection<Product1> Product1s { get; set; }
    }
}
