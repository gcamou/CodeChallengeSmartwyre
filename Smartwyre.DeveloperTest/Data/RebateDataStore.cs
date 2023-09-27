using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Infrastructure;
using System.Linq;
using System;

namespace Smartwyre.DeveloperTest.Data;

public class RebateDataStore : IRebateDataStore
{
    private readonly ApplicationDbContext _dbContext;
    public RebateDataStore(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Rebate GetRebate(string rebateIdentifier)
    {
       var rebate = _dbContext.Rebates.Where(rebate => 
                                                rebate.Identifier == rebateIdentifier)
                                    .SingleOrDefault();
        return rebate;
    }

    public void StoreCalculationResult(Rebate account, decimal rebateAmount)
    {
        var rebate = _dbContext.Rebates.Where(rebate =>
                                                rebate.Identifier == account.Identifier)
                                        .SingleOrDefault();

        if(rebate == null) throw new NullReferenceException();

        rebate.Amount = rebateAmount;

        _dbContext.Update(rebate);
        _dbContext.SaveChanges();
    }
}
