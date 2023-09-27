using System;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;
using FizzWare.NBuilder;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.Data
{
    public class ProductDataStoreTest: DbContext
    {
        [Fact]
        public void Should_Return_Product_By_Identifier()
        {
            using (var dbContext = GetInMemoryDataContextForTesting())
            {
                // Arrange
                var id = Guid.NewGuid();
                var productDataStore = new ProductDataStore(dbContext);

                var product = Builder<Product>.CreateNew()
                                                .With(product => product.Identifier = id.ToString())
                                                .Build();
                dbContext.Products.Add(product);
                dbContext.SaveChanges();

                // Act
                var result = productDataStore.GetProduct(id.ToString());

                // Assert
                Assert.NotNull(product);
                Assert.Equal(result, product);
            }
        }

        [Fact]
        public void Should_Return_Null_When_Identifier_Does_Not_Exists_In_The_Db()
        {
            using (var dbContext = GetInMemoryDataContextForTesting())
            {
                // Arrange
                var id = Guid.NewGuid();
                var productDataStore = new ProductDataStore(dbContext);

                var product = Builder<Product>.CreateNew()
                                                .Build();
                dbContext.Products.Add(product);
                dbContext.SaveChanges();

                // Act
                var result = productDataStore.GetProduct(id.ToString());

                // Assert
                Assert.Null(result);
            }
        }
    }
}