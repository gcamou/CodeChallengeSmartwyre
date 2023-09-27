using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Calculator
{
    public class FixedCashAmountCalculate : ICalculateStrategy
    {
        public decimal Calculate(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            return rebate.Amount;
        }
    }
}