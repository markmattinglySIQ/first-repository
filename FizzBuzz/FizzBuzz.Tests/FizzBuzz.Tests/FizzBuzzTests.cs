using NUnit.Framework;

namespace FizzBuzz.Tests
{
    [TestFixture]
    public class FizzBuzzTests
    {

        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "Fizz")]
        [TestCase(4, "4")]
        [TestCase(5, "Buzz")]
        [TestCase(6, "Fizz")]
        [TestCase(9, "Fizz")]
        [TestCase(10, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(18, "Fizz")]
        [TestCase(20, "Buzz")]
        [TestCase(22, "22")]
        [TestCase(30, "FizzBuzz")]
        [TestCase(100, "Buzz")]
        [TestCase(-1, "-1")]
        [TestCase(-2, "-2")]
        [TestCase(-3, "Fizz")]
        [TestCase(-4, "-4")]
        [TestCase(-5, "Buzz")]
        public void ShouldPrintExpectedResult(int sourceNumber, string expectedResult)
        {
            // Arrange
            FizzBuzzPrinter fizzBuzzPrinter = new FizzBuzzPrinter();
            
            // Act
            string returnedValue = fizzBuzzPrinter.PrintNumber(sourceNumber);

            // Assert
            Assert.That(returnedValue, Is.EqualTo(expectedResult));
        }
    }
}
