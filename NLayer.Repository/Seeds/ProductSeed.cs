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
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { productId = 1, categoryId = 1, productName = "YZFR5 Monster Kafa Karenajı", purchasePrice = 520, salePrice = 750, stock = 4 },
                new Product { productId = 2, categoryId = 1, productName = "FZ8 Fazer Debriyaj Balatası", purchasePrice = 270, salePrice = 330, stock = 8 },
                new Product { productId = 3, categoryId = 2, productName = "BMW E4 Klima Radyatörü", purchasePrice = 550, salePrice = 650, stock = 5 },
                new Product { productId = 4, categoryId = 2, productName = "FIAT Linea Motor Takozu", purchasePrice = 290, salePrice = 370, stock = 10 },
                new Product { productId = 5, categoryId = 2, productName = "Range Rover Triger Kayışı", purchasePrice = 160, salePrice = 240, stock = 14 }
                );
        }
    }
}
