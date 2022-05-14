using Inventory.Application.Interfaces;
using Inventory.Infrastructure.Interface;
using Inventory.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Services
{
    public class ProductService: IProductService
    {
        public IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<KeyValuePair<string, int>> CountOfAllProductStatus()
        {
            return _productRepository.CountOfAllProductStatuses();
            
        }

        public async Task ChangeProductStatusByProductName(string productName, string status)
        {
            if (!await _productRepository.IsValidProductName(productName))
            {
                throw new Exception("Could Find Product with this Name");
            }

            await _productRepository.ChangeProductStatus(productName, 
                (ProductStatus)Enum.Parse(typeof(ProductStatus), status));
        }


        public async Task BuyProductByProductName(string productName)
        {
            if (!await _productRepository.IsValidProductName(productName))
            {
                throw new Exception("Could Find Product with this Name");
            }

            //we don't have quantity of product so accusing that its only one product 
            await _productRepository.ChangeProductStatus(productName,
                ProductStatus.Sold);
        }
    }
}
