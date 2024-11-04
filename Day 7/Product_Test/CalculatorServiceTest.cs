//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Product_Test
//{
//    public class CalculatorServiceTest
//    {
//        private ICalculatorService _calculatorService;

//        [SetUp]
//        public void Setup()
//        {
//            //arrange
//            _calculatorService = new CalculatorService();
//        }
//        [TestCase(10,30,40)]
//        [TestCase(100,300,400)]
//        [TestCase(15,25,40)]
//        public void Add_NegativeNumbers_ShouldReturnCorrectSum(int num1,int num2,int expected)
//        {
//            //var expected = -30
//            //Act
//            var actualResult = _calculatorService.Add(num1, num2);
//            //assert
//            Assert.That(actualResult, Is.EqualTo(expected));
//        }

//        [Test]
//        public void Add_PositiveNumbers_ShouldReturnCorrectSum()
//        {
//            var expected = 30;
//            var actualResult = _calculatorService.Add(10, 20);
//            Assert.That(actualResult,Is.EqualTo(expected));
//        }
//        [Test]
//        public void Subtract_PositiveNumbers_ShouldReturnCorrectDifference()
//        {
//            var expected = 10;
//            var actualResult = _calculatorService.Subtract(30, 20);
//            Assert.That(actualResult, Is.EqualTo(expected));
//        }
//        [Test]
//        public void Subtract_NegativeNumbers_ShouldReturnCorrectDifference()
//        {
//            var expected = -10;
//            var actualResult = _calculatorService.Subtract(-30, -20);
//            Assert.That(actualResult, Is.EqualTo(expected));
//        }
//        [Test]
//        public void Multiply_PositiveNumbers_ShouldReturnCorrectAnswer()
//        {
//            var expected = 600;
//            var actualResult = _calculatorService.Multiply(30, 20);
//            Assert.That(actualResult, Is.EqualTo(expected));
//        }
//        [Test]
//        public void Multiply_NegativeNumbers_ShouldReturnCorrectAnswer()
//        {
//            var expected = 600;
//            var actualResult = _calculatorService.Multiply(-30, -20);
//            Assert.That(actualResult, Is.EqualTo(expected));
//        }
//        public void Divide_PositiveNumbers_ShouldReturnCorrectAnswer()
//        {
//            var expected = 2;
//            var actualResult = _calculatorService.Divide(40, 20);
//            Assert.That(actualResult, Is.EqualTo(expected));
//        }
//        [Test]
//        public void Divide_NegativeNumbers_ShouldReturnCorrectAnswer()
//        {
//            var expected = 2;
//            var actualResult = _calculatorService.Divide(-40, -20);
//            Assert.That(actualResult, Is.EqualTo(expected));
//        }


//    }
//}
