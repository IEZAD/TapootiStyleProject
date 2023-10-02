using _0_Framework.Domain.Common;
using ShopManagment.Domain.ProductCategoryAgg.ProductCategoryTypeAgg;

namespace ShopManagment.Domain.ProductAgg.ProductItemAgg
{
    public interface IProductItemQueryRepository : IQueryRepository<ProductCategoryType, Guid>
    {
    }
}