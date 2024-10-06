using E_commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Persistence.Configrations
{
    public class ProductCategoryConfigration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => new
            {
                x.ProductId,
                x.CategoryId,
            });

            builder.HasOne(p=>p.Product)
                .WithMany(pc=>pc.ProductCategory)
                .HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);
            
            
            builder.HasOne(p=>p.Category)
                .WithMany(pc=>pc.ProductCategory)
                .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
