using Inventory.Infrastructure.Context;
using Inventory.Infrastructure.Interface;
using Inventory.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly IGenericDbContext _context;

        public ProductRepository(IGenericDbContext context)
        {
            _context = context;
        }

        public Task<bool> IsValidProductName(string productName)
        {
            return _context.Products.AsNoTracking().AnyAsync(x => productName.Equals(x.Name));
        }

        public Task<bool> IsProductInStock(string productName)
        {
            return _context.Products.AsNoTracking().AnyAsync(x => productName.Equals(x.Name) && x.Status == ProductStatus.InStock);
        }

        public List<KeyValuePair<string, int>> CountOfAllProductStatuses()
        {
           var productStatusCount =  _context.Products.ToList().GroupBy(x => x.Status)
                .Select(x => new KeyValuePair<string,int>( x.Key.ToString(), x.Count())).ToList();

            return productStatusCount;
        }

        public async Task ChangeProductStatus(string productName, ProductStatus status)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => productName.Equals(x.Name));

            product.Status = status;

            _context.SaveChanges();
        }

    }
}

