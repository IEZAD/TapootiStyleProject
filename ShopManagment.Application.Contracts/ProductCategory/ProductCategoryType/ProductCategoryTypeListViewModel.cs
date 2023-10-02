namespace ShopManagment.Application.Contracts.ProductCategory.ProductCategoryType
{
    public class ProductCategoryTypeListViewModel
    {
        public Guid Id { get; set; }

        public int OrderId { get; set; }

        public int SubTypeCount { get; set; }

        public string Type { get; set; } = string.Empty;
    }
}