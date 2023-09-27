using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Validators;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.Validators
{
    public class AmountPerUomValidatorTest
    {
        [Fact]
        public void Validate_WithValidData_ShouldReturnTrue()
        {
            // Arrange
            var rebate = new Rebate { Amount = 100 };
            var product = new Product { SupportedIncentives = SupportedIncentiveType.AmountPerUom };
            var request = new CalculateRebateRequest { Volume = 10 };

            var validator = new AmountPerUomValidator();

            // Act
            bool result = validator.Validate(rebate, product, request);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Validate_WithNullRebate_ShouldReturnFalse()
        {
            // Arrange
            Rebate rebate = null;
            var product = new Product { SupportedIncentives = SupportedIncentiveType.AmountPerUom };
            var request = new CalculateRebateRequest { Volume = 10 };

            var validator = new AmountPerUomValidator();

            // Act
            bool result = validator.Validate(rebate, product, request);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Validate_WithNullProduct_ShouldReturnFalse()
        {
            // Arrange
            var rebate = new Rebate { Amount = 100 };
            Product product = null;
            var request = new CalculateRebateRequest { Volume = 10 };

            var validator = new AmountPerUomValidator();

            // Act
            bool result = validator.Validate(rebate, product, request);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Validate_WithZeroAmount_ShouldReturnFalse()
        {
            // Arrange
            var rebate = new Rebate { Amount = 0 };
            var product = new Product { SupportedIncentives = SupportedIncentiveType.AmountPerUom };
            var request = new CalculateRebateRequest { Volume = 10 };

            var validator = new AmountPerUomValidator();

            // Act
            bool result = validator.Validate(rebate, product, request);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Validate_WithZeroVolume_ShouldReturnFalse()
        {
            // Arrange
            var rebate = new Rebate { Amount = 100 };
            var product = new Product { SupportedIncentives = SupportedIncentiveType.AmountPerUom };
            var request = new CalculateRebateRequest { Volume = 0 };

            var validator = new AmountPerUomValidator();

            // Act
            bool result = validator.Validate(rebate, product, request);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Validate_WithUnsupportedIncentive_ShouldReturnFalse()
        {
            // Arrange
            var rebate = new Rebate { Amount = 100 };
            var product = new Product { SupportedIncentives = SupportedIncentiveType.FixedCashAmount };
            var request = new CalculateRebateRequest { Volume = 10 };

            var validator = new AmountPerUomValidator();

            // Act
            bool result = validator.Validate(rebate, product, request);

            // Assert
            Assert.False(result);
        }
    }
}