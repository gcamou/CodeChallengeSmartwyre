using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Validators
{
    public class FixedCashAmountValidator : IValidator
    {
        public bool Validate(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            var nonNullReference = rebate != null && product != null;

            if (!nonNullReference) return false;

            var nonZeroValue = rebate.Amount > 0;
            var isFixedCashAmount = product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount);

            return nonNullReference && nonZeroValue && isFixedCashAmount;
        }
    }
}