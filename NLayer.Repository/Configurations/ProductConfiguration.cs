using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nlayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x=>x.productId);
            builder.Property(x => x.productId).UseIdentityColumn();
            builder.Property(x => x.productName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.purchasePrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.salePrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.stock).IsRequired();
            builder.ToTable("Products");
        }
    }
}
