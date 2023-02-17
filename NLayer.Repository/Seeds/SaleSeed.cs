using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nlayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class SaleSeed : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasData(
                new Sale { saleId = 1, productId = 1, salesQuantity = 2, saleDate = new DateTime(2022, 05, 26), comment = "Ahmet abiye satış yapıldı.vsvsvs" },
                new Sale { saleId = 2, productId = 4, salesQuantity = 1, saleDate = new DateTime(2022, 06, 02) },
                new Sale { saleId = 3, productId = 5, salesQuantity = 3, saleDate = new DateTime(2022, 06, 05) }
                );
        }
    }
}
