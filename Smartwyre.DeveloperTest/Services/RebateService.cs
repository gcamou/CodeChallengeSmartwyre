using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Validators;
using Smartwyre.DeveloperTest.Extensions;
using System.Collections.Generic;
using Smartwyre.DeveloperTest.Calculator;
using System;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    private readonly IRebateDataStore _rebateDataStore;
    private readonly IProductDataStore _productDataStore;
    private readonly Dictionary<IncentiveType, ICalculateStrategy> _calculator;
    public RebateService(IRebateDataStore rebateDataStore, IProductDataStore productDataStore)
    {
        _rebateDataStore = rebateDataStore;
        _productDataStore = productDataStore;

        _calculator = new Dictionary<IncentiveType, ICalculateStrategy>
            {
                { IncentiveType.FixedCashAmount, new FixedCashAmountCalculate() },
                { IncentiveType.FixedRateRebate, new FixedRateRebateCalculate() },
                { IncentiveType.AmountPerUom, new AmountPerUomCalculate() }
            };
    }

    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        var result = new CalculateRebateResult()
        {
            Success = false
        };

        Rebate rebate = _rebateDataStore.GetRebate(request.RebateIdentifier);

        if(rebate == null) return result;

        Product product = _productDataStore.GetProduct(request.ProductIdentifier);

        if (_calculator.TryGetValue(rebate.Incentive, out var strategy))
        {
            var validator = HelperValidators.Validators[rebate.Incentive.GetDescription()];

            result.Success = validator.Validate(rebate, product, request);

            if (result.Success)
            {
                var rebateAmount = strategy.Calculate(rebate, product, request);

                _rebateDataStore.StoreCalculationResult(rebate, rebateAmount);
            }
        }

        return result;
    }
}
