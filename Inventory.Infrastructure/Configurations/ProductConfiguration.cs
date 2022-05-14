using Inventory.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .ToTable("Products");


            builder
                .HasKey(a => a.ProdcutId);

            builder
                .Property(m => m.ProdcutId)
                .UseIdentityColumn();

            builder
                .HasOne(m => m.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(m => m.CategoryId);


            //Make field required and fix lenght here
        }
    }
}
