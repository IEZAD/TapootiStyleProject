using System.ComponentModel.DataAnnotations;

namespace ShopManagment.Application.Contracts.ProductCategory.ProductCategoryType
{
    public class UpdateProductCategoryType
    {
        public Guid Id { get; set; }

        public Guid? ParentProductCategoryTypeId { get; set; }

        [Range(1, 1000, ErrorMessage = "The value must be greater than 0")]
        public int OrderId { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum length for Type is 100")]
        public string Type { get; set; } = string.Empty;
    }
}