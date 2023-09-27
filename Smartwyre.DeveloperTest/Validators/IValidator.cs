using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Validators
{
    public interface IValidator
    {
        public bool Validate(Rebate rebate, Product product, CalculateRebateRequest request);
    }
}