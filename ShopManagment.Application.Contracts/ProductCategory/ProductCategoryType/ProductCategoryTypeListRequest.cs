namespace ShopManagment.Application.Contracts.ProductCategory.ProductCategoryType
{
    public class ProductCategoryTypeListRequest
    {
        public int Page { get; set; } = 1;

        public Guid? ParentProductCategoryTypeId { get; set; }
    }
}