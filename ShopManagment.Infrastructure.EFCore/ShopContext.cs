using Microsoft.EntityFrameworkCore;
using ShopManagment.Infrastructure.EFCore.Mapping;
using ShopManagment.Domain.ProductCategoryAgg.ProductCategoryTypeAgg;

namespace ShopManagment.Infrastructure.EFCore
{
    public class ShopContext : DbContext
    {
        public DbSet<ProductCategoryType> ProductCategoryTypes { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryTypeMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}