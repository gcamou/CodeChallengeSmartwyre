using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data
{
    public interface IProductDataStore
    {
        public Product GetProduct(string productIdentifier);
    }
}