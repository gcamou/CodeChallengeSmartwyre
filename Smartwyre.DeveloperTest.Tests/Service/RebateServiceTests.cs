using Xunit;
using Moq;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Services;
using System;

namespace Smartwyre.DeveloperTest.Tests.Service
{
    public class RebateServiceTests
    {
        [Fact]
        public void Should_Return_True_When_Calcule_The_Rebate_And_Incentive_Is_FixedCashAmount()
        {
            // Arrange
            var rebateDataStoreMock = new Mock<IRebateDataStore>();
            var productDataStoreMock = new Mock<IProductDataStore>();

            var rebateService = new RebateService(rebateDataStoreMock.Object, productDataStoreMock.Object);

            var request = new CalculateRebateRequest
            {
                RebateIdentifier = Guid.NewGuid().ToString(),
                ProductIdentifier = Guid.NewGuid().ToString(),
                Volume = 10
            };

            var rebate = new Rebate
            {
                Incentive = IncentiveType.FixedCashAmount,
                Percentage = 0.1m,
                Amount = 10
            };

            var product = new Product
            {
                Price = 100,
                SupportedIncentives = SupportedIncentiveType.FixedCashAmount
            };

            rebateDataStoreMock.Setup(rebate =>
                                        rebate.GetRebate(request.RebateIdentifier))
                                .Returns(rebate);
            productDataStoreMock.Setup(product =>
                                        product.GetProduct(request.ProductIdentifier))
                                .Returns(product);

            // Act
            var result = rebateService.Calculate(request);

            // Assert
            Assert.True(result.Success);
        }
        [Fact]
        public void Should_Return_True_When_Calcule_The_Rebate_And_Incentive_Is_FixedRateRebate()
        {
            // Arrange
            var rebateDataStoreMock = new Mock<IRebateDataStore>();
            var productDataStoreMock = new Mock<IProductDataStore>();

            var rebateService = new RebateService(rebateDataStoreMock.Object, productDataStoreMock.Object);

            var request = new CalculateRebateRequest
            {
                RebateIdentifier = Guid.NewGuid().ToString(),
                ProductIdentifier = Guid.NewGuid().ToString(),
                Volume = 10
            };

            var rebate = new Rebate
            {
                Incentive = IncentiveType.FixedRateRebate,
                Percentage = 0.1m,
                Amount = 10
            };

            var product = new Product
            {
                Price = 100,
                SupportedIncentives = SupportedIncentiveType.FixedRateRebate
            };

            rebateDataStoreMock.Setup(rebate =>
                                        rebate.GetRebate(request.RebateIdentifier))
                                .Returns(rebate);
            productDataStoreMock.Setup(product =>
                                        product.GetProduct(request.ProductIdentifier))
                                .Returns(product);

            // Act
            var result = rebateService.Calculate(request);

            // Assert
            Assert.True(result.Success);
        }
        [Fact]
        public void Should_Return_True_When_Calcule_The_Rebate_And_Incentive_Is_AmountPerUom()
        {
            // Arrange
            var rebateDataStoreMock = new Mock<IRebateDataStore>();
            var productDataStoreMock = new Mock<IProductDataStore>();

            var rebateService = new RebateService(rebateDataStoreMock.Object, productDataStoreMock.Object);

            var request = new CalculateRebateRequest
            {
                RebateIdentifier = Guid.NewGuid().ToString(),
                ProductIdentifier = Guid.NewGuid().ToString(),
                Volume = 10
            };

            var rebate = new Rebate
            {
                Incentive = IncentiveType.AmountPerUom,
                Percentage = 0.1m,
                Amount = 10

            };

            var product = new Product
            {
                Price = 100,
                SupportedIncentives = SupportedIncentiveType.AmountPerUom
            };

            rebateDataStoreMock.Setup(rebate =>
                                        rebate.GetRebate(request.RebateIdentifier))
                                .Returns(rebate);
            productDataStoreMock.Setup(product =>
                                        product.GetProduct(request.ProductIdentifier))
                                .Returns(product);

            // Act
            var result = rebateService.Calculate(request);

            // Assert
            Assert.True(result.Success);
        }
        
        [Fact]
        public void Should_Return_False_When_Calcule_The_Rebate_And_Incentive_Is_Not_FixedCashAmount()
        {
            // Arrange
            var rebateDataStoreMock = new Mock<IRebateDataStore>();
            var productDataStoreMock = new Mock<IProductDataStore>();

            var rebateService = new RebateService(rebateDataStoreMock.Object, productDataStoreMock.Object);

            var request = new CalculateRebateRequest
            {
                RebateIdentifier = Guid.NewGuid().ToString(),
                ProductIdentifier = Guid.NewGuid().ToString(),
                Volume = 10
            };

            var rebate = new Rebate
            {
                Incentive = IncentiveType.AmountPerUom,
                Percentage = 0.1m,
                Amount = 10

            };

            var product = new Product
            {
                Price = 100,
                SupportedIncentives = SupportedIncentiveType.FixedCashAmount
            };

            rebateDataStoreMock.Setup(rebate =>
                                        rebate.GetRebate(request.RebateIdentifier))
                                .Returns(rebate);
            productDataStoreMock.Setup(product =>
                                        product.GetProduct(request.ProductIdentifier))
                                .Returns(product);

            // Act
            var result = rebateService.Calculate(request);

            // Assert
            Assert.False(result.Success);
        }
        
        [Fact]
        public void Should_Return_False_When_Calcule_The_Rebate_And_Incentive_Is_Not_FixedRateRebate()
        {
            // Arrange
            var rebateDataStoreMock = new Mock<IRebateDataStore>();
            var productDataStoreMock = new Mock<IProductDataStore>();

            var rebateService = new RebateService(rebateDataStoreMock.Object, productDataStoreMock.Object);

            var request = new CalculateRebateRequest
            {
                RebateIdentifier = Guid.NewGuid().ToString(),
                ProductIdentifier = Guid.NewGuid().ToString(),
                Volume = 10
            };

            var rebate = new Rebate
            {
                Incentive = IncentiveType.FixedCashAmount,
                Percentage = 0.1m,
                Amount = 10

            };

            var product = new Product
            {
                Price = 100,
                SupportedIncentives = SupportedIncentiveType.FixedRateRebate
            };

            rebateDataStoreMock.Setup(rebate =>
                                        rebate.GetRebate(request.RebateIdentifier))
                                .Returns(rebate);
            productDataStoreMock.Setup(product =>
                                        product.GetProduct(request.ProductIdentifier))
                                .Returns(product);

            // Act
            var result = rebateService.Calculate(request);

            // Assert
            Assert.False(result.Success);
        }
        
        [Fact]
        public void Should_Return_False_When_Calcule_The_Rebate_And_Incentive_Is_Not_AmountPerUom()
        {
            // Arrange
            var rebateDataStoreMock = new Mock<IRebateDataStore>();
            var productDataStoreMock = new Mock<IProductDataStore>();

            var rebateService = new RebateService(rebateDataStoreMock.Object, productDataStoreMock.Object);

            var request = new CalculateRebateRequest
            {
                RebateIdentifier = Guid.NewGuid().ToString(),
                ProductIdentifier = Guid.NewGuid().ToString(),
                Volume = 10
            };

            var rebate = new Rebate
            {
                Incentive = IncentiveType.FixedRateRebate,
                Percentage = 0.1m,
                Amount = 10

            };

            var product = new Product
            {
                Price = 100,
                SupportedIncentives = SupportedIncentiveType.AmountPerUom
            };

            rebateDataStoreMock.Setup(rebate =>
                                        rebate.GetRebate(request.RebateIdentifier))
                                .Returns(rebate);
            productDataStoreMock.Setup(product =>
                                        product.GetProduct(request.ProductIdentifier))
                                .Returns(product);

            // Act
            var result = rebateService.Calculate(request);

            // Assert
            Assert.False(result.Success);
        }
    }
}