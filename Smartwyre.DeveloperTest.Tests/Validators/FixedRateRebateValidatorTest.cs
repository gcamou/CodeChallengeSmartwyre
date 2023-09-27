using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Validators;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.Validators
{
    public class FixedRateRebateValidatorTest
    {
        [Fact]
        public void Validate_WithValidData_ShouldReturnTrue()
        {
            // Arrange
            var rebate = new Rebate { Amount = 100, Percentage = 100 };
            var product = new Product { Price = 100, SupportedIncentives = SupportedIncentiveType.FixedRateRebate };
            var request = new CalculateRebateRequest { Volume = 10 };


            var validator = new FixedRateRebateValidator();

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
            var product = new Product { Price = 100, SupportedIncentives = SupportedIncentiveType.FixedRateRebate };
            var request = new CalculateRebateRequest { Volume = 10 };

            var validator = new FixedRateRebateValidator();

            // Act
            bool result = validator.Validate(rebate, product, request);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Validate_WithNullProduct_ShouldReturnFalse()
        {
            // Arrange
            var rebate = new Rebate { Amount = 100, Percentage = 100 };
            Product product = null;
            var request = new CalculateRebateRequest { Volume = 10 };

            var validator = new FixedRateRebateValidator();

            // Act
            bool result = validator.Validate(rebate, product, request);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Validate_WithZeroPercentage_ShouldReturnFalse()
        {
            // Arrange
            var rebate = new Rebate { Amount = 100, Percentage = 0 };
            var product = new Product { Price = 100, SupportedIncentives = SupportedIncentiveType.FixedRateRebate };
            var request = new CalculateRebateRequest { Volume = 10 };

            var validator = new FixedRateRebateValidator();

            // Act
            bool result = validator.Validate(rebate, product, request);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Validate_WithZeroVolume_ShouldReturnFalse()
        {
            // Arrange
            var rebate = new Rebate { Amount = 100, Percentage = 100 };
            var product = new Product { Price = 100, SupportedIncentives = SupportedIncentiveType.FixedRateRebate };
            var request = new CalculateRebateRequest { Volume = 0 };

            var validator = new FixedRateRebateValidator();

            // Act
            bool result = validator.Validate(rebate, product, request);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Validate_WithUnsupportedIncentive_ShouldReturnFalse()
        {
            // Arrange
            var rebate = new Rebate { Amount = 100, Percentage = 100 };
            var product = new Product { Price = 100, SupportedIncentives = SupportedIncentiveType.AmountPerUom };
            var request = new CalculateRebateRequest { Volume = 10 };

            var validator = new FixedRateRebateValidator();

            // Act
            bool result = validator.Validate(rebate, product, request);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Validate_WithZeroPrice_ShouldReturnFalse()
        {
            // Arrange
            var rebate = new Rebate { Amount = 100, Percentage = 100 };
            var product = new Product { Price = 0, SupportedIncentives = SupportedIncentiveType.FixedRateRebate };
            var request = new CalculateRebateRequest { Volume = 10 };

            var validator = new FixedRateRebateValidator();

            // Act
            bool result = validator.Validate(rebate, product, request);

            // Assert
            Assert.False(result);
        }
    }
}