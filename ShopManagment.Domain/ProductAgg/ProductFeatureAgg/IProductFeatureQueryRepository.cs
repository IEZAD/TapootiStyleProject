using _0_Framework.Domain.Common;
using ShopManagment.Domain.ProductCategoryAgg.ProductCategoryBrandAgg;

namespace ShopManagment.Domain.ProductAgg.ProductFeatureAgg
{
    public interface IProductFeatureQueryRepository : IQueryRepository<ProductCategoryBrand, Guid>
    {
    }
}