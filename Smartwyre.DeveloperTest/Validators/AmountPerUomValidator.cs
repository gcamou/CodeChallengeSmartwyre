using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Validators
{
    public class AmountPerUomValidator : IValidator
    {
        public bool Validate(Rebate rebate, Product product, CalculateRebateRequest request)
        {
            var nonNullReference = rebate != null && product != null;

            if (!nonNullReference) return false;

            var nonZeroValue = rebate.Amount > 0 && request.Volume > 0;
            var isAmountPerUom = product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom);


            return nonNullReference && nonZeroValue && isAmountPerUom;
        }
    }
}