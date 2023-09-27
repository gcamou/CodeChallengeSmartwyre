using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Extensions;


namespace Smartwyre.DeveloperTest.Validators
{
    public static class HelperValidators
    {
        public static readonly Dictionary<string, IValidator> Validators = new Dictionary<string, IValidator>()
        {
            {IncentiveType.FixedCashAmount.GetDescription(), new FixedCashAmountValidator()},
            {IncentiveType.FixedRateRebate.GetDescription(), new FixedRateRebateValidator()},
            {IncentiveType.AmountPerUom.GetDescription(), new AmountPerUomValidator()},
        };
    }
}