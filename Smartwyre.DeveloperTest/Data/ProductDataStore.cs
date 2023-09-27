using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Infrastructure;
using System.Linq;

namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore : IProductDataStore
{
    private readonly ApplicationDbContext _dbContext;

    public ProductDataStore(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Product GetProduct(string productIdentifier)
    {
        var product = _dbContext.Products.Where(product =>
                                                    product.Identifier == productIdentifier)
                                        .SingleOrDefault();
        return product;
    }
}
