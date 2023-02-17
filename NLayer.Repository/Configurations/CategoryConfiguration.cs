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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.categoryId);
            builder.Property(x => x.categoryId).UseIdentityColumn();
            builder.Property(x => x.categoryName).IsRequired().HasMaxLength(50);

            builder.ToTable("Categories");
        }
    }
}
