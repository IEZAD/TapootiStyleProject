using _0_Framework.Domain.Pagination;
using _0_Framework.Apllication.Messaging.ApiWrapper;

namespace ShopManagment.Application.Contracts.ProductCategory.ProductCategoryType
{
    public interface IProductCategoryTypeApplication
    {
        Task<ApiWrapperResponse<List<MenuItemViewModel>>> ExecuteAsync();

        Task<ApiWrapperResponse<ProductCategoryTypeViewModel>> GetDetailsAsync(Guid id);

        Task<ApiWrapperResponse<ProductCategoryTypeViewModel>> DeleteAsync(Guid request);

        Task<ApiWrapperResponse<ProductCategoryTypeViewModel>> CreateAsync(CreateProductCategoryType request);

        Task<ApiWrapperResponse<ProductCategoryTypeViewModel>> UpdateAsync(UpdateProductCategoryType request);

        Task<ApiWrapperResponse<PagedResult<ProductCategoryTypeViewModel>>> SearchAsync(ProductCategoryTypeSearchModel request);

        Task<ApiWrapperResponse<PagedResult<ProductCategoryTypeListViewModel>>> GetProductCategoryTypesAsync(ProductCategoryTypeListRequest request);
    }
}