namespace ShopManagment.Application.Contracts.ProductCategory.ProductCategoryType
{
    public class MenuItemViewModel
    {
        public Guid Id { get; set; }

        public int OrderId { get; set; }

        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public List<MenuItemViewModel> SubMenu { get; set; }
    }
}