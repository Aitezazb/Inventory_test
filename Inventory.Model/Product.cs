using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Model
{
    public class Product
    {
        public int ProdcutId { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Decription { get; set; }
        public int Weight { get; set; }
        public ProductStatus Status {get;set;}
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public enum ProductStatus
    {
        Sold = 0,
        InStock = 1,
        Damaged = 2
    }
}