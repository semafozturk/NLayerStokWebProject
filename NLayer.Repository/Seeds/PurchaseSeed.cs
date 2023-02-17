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
    public class PurchaseSeed : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasData(
                new Purchase { purchaseId = 1, productId = 3, purchasesQuantity = 3, purchaseDate = new DateTime(2022, 01, 20), comment = "AXC Araba parçaları ile haftalık alım anlaşması yaptık. Konuştuğum kişi : Mehmet abi." }
                );
        }
    }
}
