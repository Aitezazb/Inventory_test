using Inventory.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
               .ToTable("Categories");


            builder
                .HasKey(a => a.CategoryId);

            builder
                .Property(m => m.CategoryId)
                .UseIdentityColumn();

            //Make field required and fix lenght here
        }
    }
}
