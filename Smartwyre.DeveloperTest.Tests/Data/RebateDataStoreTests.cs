using System;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;
using FizzWare.NBuilder;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.Data
{
    public class RebateDataStoreTests : DbContext
    {
        [Fact]
        public void Should_Return_Rebate_By_Identifier()
        {
            using (var dbContext = GetInMemoryDataContextForTesting())
            {
                // Arrange
                var id = Guid.NewGuid();
                var rebateDataStore = new RebateDataStore(dbContext);

                var rebate = Builder<Rebate>.CreateNew()
                                                .With(rebate => rebate.Identifier = id.ToString())
                                                .Build();
                dbContext.Rebates.Add(rebate);
                dbContext.SaveChanges();

                // Act
                var result = rebateDataStore.GetRebate(id.ToString());

                // Assert
                Assert.NotNull(rebate);
                Assert.Equal(result, rebate);
            }
        }

        [Fact]
        public void Should_Return_Null_When_Identifier_Does_Not_Exists_In_The_Db()
        {
            using (var dbContext = GetInMemoryDataContextForTesting())
            {
                // Arrange
                var id = Guid.NewGuid();
                var rebateDataStore = new RebateDataStore(dbContext);

                var rebate = Builder<Rebate>.CreateNew()
                                                .Build();
                dbContext.Rebates.Add(rebate);
                dbContext.SaveChanges();

                // Act
                var result = rebateDataStore.GetRebate(id.ToString());

                // Assert
                Assert.Null(result);
            }
        }
        
        [Fact]
        public void Should_Rebate_Amount_Updated_As_Expected()
        {
            using (var dbContext = GetInMemoryDataContextForTesting())
            {
                // Arrange
                var id = Guid.NewGuid();
                var amount = 10000m;
                var rebateDataStore = new RebateDataStore(dbContext);

                var rebate = Builder<Rebate>.CreateNew()
                                                .With(rebate => rebate.Identifier = id.ToString())
                                                .With(rebate => rebate.Amount = amount)
                                                .Build();
                dbContext.Rebates.Add(rebate);
                dbContext.SaveChanges();

                // Act
                var expectedAmoun = 20000m;
                rebateDataStore.StoreCalculationResult(rebate, expectedAmoun);


                var expected = rebateDataStore.GetRebate(rebate.Identifier);

                // Assert
                Assert.NotNull(rebate);
                Assert.NotNull(expected);
                Assert.Equal(expected.Amount, expectedAmoun);
            }
        }
        
        [Fact]
        public void Should_Rebate_Error_Exception_When_The_Rebate_Does_Not_Exist()
        {
            using (var dbContext = GetInMemoryDataContextForTesting())
            {
                // Arrange
                var id = Guid.NewGuid();
                var amount = 10000m;
                var rebateDataStore = new RebateDataStore(dbContext);

                var rebate = Builder<Rebate>.CreateNew()
                                                .With(rebate => rebate.Identifier = id.ToString())
                                                .With(rebate => rebate.Amount = amount)
                                                .Build();

                // Act
                var expectedAmoun = 20000m;

                // Assert
                Assert.Throws<NullReferenceException>(()=>rebateDataStore.StoreCalculationResult(rebate, expectedAmoun));
            }
        }
    }
}