using Inventory.Infrastructure.Configurations;
using Inventory.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Context
{
    public interface IGenericDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        int SaveChanges();

    }

    public class GenericDbContext : DbContext, IGenericDbContext
    {
        public GenericDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            
            //SeedProduct(builder);
        }

        //private void SeedProduct(ModelBuilder builder)
        //{
        //    var product = new List<Product>()
        //    {
        //        new Product
        //        {
        //            ProdcutId = 1,
        //            Name = "Sold Product",
        //            Decription = "This is a Sold product",
        //            Status = ProductStatus.Sold,
        //            Weight = 19,
        //            Barcode = "123456789",
                   
        //        },
        //        new Product
        //        {
        //            ProdcutId = 2,
        //            Name = "InStock Product",
        //            Decription = "This is a inStock product",
        //            Status = ProductStatus.InStock,
        //            Weight = 19,
        //            Barcode = "123456789",
                   
        //        },
        //        new Product
        //        {
        //            ProdcutId = 3,
        //            Name = "Damaged Product",
        //            Decription = "This is a damaged product",
        //            Status = ProductStatus.Damaged,
        //            Weight = 19,
        //            Barcode = "123456789",
                    
        //        }
        //    };

        //    builder.Entity<Product>().HasData(product);
        //}
    }
}
