using ProductManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Test
{
    [TestFixture]
    public class ProductServiceTest
    {
        private ProductService _productService;

        [SetUp]
        public void Setup()
        {
            _productService = new ProductService();
        }

        [Test]
        public void AddProduct_WhenNewProduct_Should_IncreaseStock()
        {
            // Arrange
            var product = new Product() { Name="Laptop",Quantity = 10};
            _productService.AddProduct(product);

            // Act
            _productService.AddProduct(new Product { Name = "Laptop", Quantity = 5 });
            Assert.That(_productService.CheckStock("Laptop"), Is.EqualTo(15));
        }
        [Test]
        public void CheckStock_WhenProductDoesNotExist_ShouldReturnZero()
        {
            var stock = _productService.CheckStock("Sample product");
            Assert.AreEqual(0, stock);
        }
        [Test]
        public void UpdateStock_WhenProductExists_ShouldUpdateQuantity()
        {
            var product = new Product() { Name = "Laptop", Quantity = 10 };
            _productService.AddProduct(product);

            var updateResult = _productService.UpdateStock("Laptop", 12);
            Assert.IsTrue(updateResult);
            Assert.That(_productService.CheckStock("Laptop"),Is.EqualTo(12));
        }
        [Test]
        public void UpdateStock_WhenProductDoesNotExists_ShouldReturnFalse()
        {
            var result = _productService.UpdateStock("NoProduct", 12); ;
            Assert.IsFalse(result);
        }
    }
}
