using _0_Framework.Infrastructure.Common;
using ShopManagment.Domain.ProductCategoryAgg.ProductCategoryTypeAgg;

namespace ShopManagment.Infrastructure.EFCore.Repository.ProductCategory
{
    public class ProductCategoryTypeRepository : RepositoryBase<ProductCategoryType, Guid>, IProductCategoryTypeRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryTypeRepository(ShopContext context) : base(context)
        {
            _context = context;
        }
    }
}