
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Smartwyre.DeveloperTest.Infrastructure;

namespace Smartwyre.DeveloperTest.Tests.Data
{
    public class DbContext
    {
        private InMemoryDatabaseRoot _inMemoryDatabaseRoot = null;

        protected ApplicationDbContext GetInMemoryDataContextForTesting()
        {
            _inMemoryDatabaseRoot = new InMemoryDatabaseRoot();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase(databaseName: "SmartwyreDb", _inMemoryDatabaseRoot)
             .ConfigureWarnings(x => x.Ignore(CoreEventId.ManyServiceProvidersCreatedWarning))
             .Options;

            return new ApplicationDbContext(options);
        }
    }
}