using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Calculator
{
    public interface ICalculateStrategy
    {
        decimal Calculate(Rebate rebate, Product product, CalculateRebateRequest request);
    }
}