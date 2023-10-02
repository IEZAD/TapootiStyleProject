namespace ShopManagment.Application.Contracts.ProductCategory.ProductCategoryType
{
    public class ProductCategoryTypeViewModel
    {
        public Guid Id { get; set; }

        public int OrderId { get; set; }

        public string Type { get; set; } = string.Empty;

        public Guid? ParentProductCategoryTypeId { get; set; }
    }
}