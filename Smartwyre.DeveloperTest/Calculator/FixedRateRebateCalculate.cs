using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Calculator
{
    public class FixedRateRebateCalculate : ICalculateStrategy
    {
        public decimal Calculate(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            return product.Price * rebate.Percentage * request.Volume;
        }
    }

}