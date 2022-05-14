using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interfaces
{
    public interface IProductService
    {
        Task BuyProductByProductName(string productName);
        Task ChangeProductStatusByProductName(string productname, string status);
        List<KeyValuePair<string, int>> CountOfAllProductStatus();
    }
}
