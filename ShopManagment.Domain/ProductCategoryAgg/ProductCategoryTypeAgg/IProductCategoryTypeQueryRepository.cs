using _0_Framework.Domain.Common;
using _0_Framework.Domain.Pagination;
using ShopManagment.Application.Contracts.ProductCategory.ProductCategoryType;

namespace ShopManagment.Domain.ProductCategoryAgg.ProductCategoryTypeAgg
{
    public interface IProductCategoryTypeQueryRepository : IQueryRepository<ProductCategoryType, Guid>
    {
        Task<PagedResult<ProductCategoryTypeViewModel>> Search(ProductCategoryTypeSearchModel searchModel);
    }
}