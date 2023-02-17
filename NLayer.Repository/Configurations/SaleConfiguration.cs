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
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(x=>x.saleId);
            builder.Property(x => x.saleId).UseIdentityColumn();
            builder.Property(x => x.salesQuantity).IsRequired();
            builder.Property(x=>x.saleDate).IsRequired();
            builder.Property(x => x.comment).HasMaxLength(150);
        }
    }
}
