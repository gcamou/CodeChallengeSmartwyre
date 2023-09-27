using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Validators
{
    public class FixedRateRebateValidator : IValidator
    {
        public bool Validate(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            var nonNullReference = rebate != null && product != null;

            if (!nonNullReference) return false;

            var nonZeroValue = rebate.Percentage > 0 && product.Price > 0 && request.Volume > 0;
            var isFixedRateRebate = product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate);

            return nonNullReference && nonZeroValue && isFixedRateRebate;
        }
    }
}