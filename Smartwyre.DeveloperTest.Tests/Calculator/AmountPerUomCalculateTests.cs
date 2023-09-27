using Xunit;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Calculator;

namespace Smartwyre.DeveloperTest.Tests.Calculator
{
    public class AmountPerUomCalculateTests
    {
        [Fact]
        public void Should_Return_True_When_The_Calculate_Is_Correct()
        {
            // Arrange
            var rebate = new Rebate { Amount = 10 };
            var product = new Product(); 
            var request = new CalculateRebateRequest { Volume = 5 };

            var calculator = new AmountPerUomCalculate();

            var expected = rebate.Amount * request.Volume;

            // Act
            var result = calculator.Calculate(rebate, product, request);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Should_Return_False_When_The_Calculate_Is_Not_Correct()
        {
            // Arrange

            var rebate = new Rebate { Amount = 10 };
            var product = new Product(); 
            var request = new CalculateRebateRequest { Volume = 5 };

            var calculator = new AmountPerUomCalculate();

            var expected = 10;

            // Act
            var result = calculator.Calculate(rebate, product, request);

            // Assert
            Assert.NotEqual(expected, result);
        }
    }
}