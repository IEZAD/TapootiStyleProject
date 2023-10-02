using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain.ProductCategoryAgg.ProductCategoryTypeAgg;

namespace ShopManagment.Infrastructure.EFCore.Mapping
{
    public class ProductCategoryTypeMapping : IEntityTypeConfiguration<ProductCategoryType>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryType> builder)
        {
            builder.ToTable("ProductCategoryTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type).IsRequired().HasMaxLength(100);
            builder.Property(x => x.OrderId).IsRequired().HasMaxLength(55);
        }
    }
}