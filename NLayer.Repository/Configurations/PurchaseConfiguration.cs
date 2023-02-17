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
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(x=>x.purchaseId);
            builder.Property(x => x.purchaseId).UseIdentityColumn();
            builder.Property(x => x.purchasesQuantity).IsRequired();
            builder.Property(x => x.purchaseDate).IsRequired();
            builder.Property(x => x.comment).HasMaxLength(150);
        }
    }
}
