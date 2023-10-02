using ShopManagment.Application;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Infrastructure.EFCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagment.Domain.ProductCategoryAgg.ProductCategoryTypeAgg;
using ShopManagment.Infrastructure.EFCore.Repository.ProductCategory;
using ShopManagment.Application.Contracts.ProductCategory.ProductCategoryType;

namespace ShopManagment.Configuration
{
    public class ShopManagmentBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryTypeRepository, ProductCategoryTypeRepository>();
            services.AddTransient<IProductCategoryTypeApplication, ProductCategoryTypeApplication>();
            services.AddTransient<IProductCategoryTypeQueryRepository, ProductCategoryTypeQueryRepository>();

            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}