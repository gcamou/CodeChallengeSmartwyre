using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Calculator
{
    public class AmountPerUomCalculate : ICalculateStrategy
    {
        public decimal Calculate(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            return rebate.Amount * request.Volume;
        }
    }
}