using Inventory.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Interface
{
    public interface IProductRepository
    {
        Task ChangeProductStatus(string productName, ProductStatus status);
        List<KeyValuePair<string, int>> CountOfAllProductStatuses();
        Task<bool> IsValidProductName(string productName);
    }
}
