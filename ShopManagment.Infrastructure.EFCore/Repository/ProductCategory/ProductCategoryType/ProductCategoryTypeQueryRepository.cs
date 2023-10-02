using _0_Framework.Domain.Pagination;
using _0_Framework.Infrastructure.Common;
using _0_Framework.Apllication.Pagination;
using ShopManagment.Domain.ProductCategoryAgg.ProductCategoryTypeAgg;
using ShopManagment.Application.Contracts.ProductCategory.ProductCategoryType;

namespace ShopManagment.Infrastructure.EFCore.Repository.ProductCategory
{
    public class ProductCategoryTypeQueryRepository : QueryRepositoryBase<ProductCategoryType, Guid>, IProductCategoryTypeQueryRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryTypeQueryRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedResult<ProductCategoryTypeViewModel>> Search(ProductCategoryTypeSearchModel searchModel)
        {
            var query = _context.ProductCategoryTypes.Select(x => new ProductCategoryTypeViewModel
            {
                Id = x.Id,
                Type = x.Type,
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Type))
                query = query.Where(x => x.Type.Contains(searchModel.Type));

            return query.OrderByDescending(x => x.Id).ToList().ToPagedResult(searchModel.page);
        }
    }
}