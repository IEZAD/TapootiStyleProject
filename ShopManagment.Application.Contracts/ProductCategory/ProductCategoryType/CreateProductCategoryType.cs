using System.ComponentModel.DataAnnotations;

namespace ShopManagment.Application.Contracts.ProductCategory.ProductCategoryType
{
    public class CreateProductCategoryType
    {
        [Required(ErrorMessage = "Type is Required")]
        [MaxLength(100, ErrorMessage = "Maximum length for Type is 100")]
        public string Type { get; set; } = string.Empty;

        public Guid? ParentProductCategoryTypeId { get; set; }

        [Required(ErrorMessage = "OrderId is Required")]
        [Range(1, 1000, ErrorMessage = "The value must be greater than 0")]
        public int OrderId { get; set; }
    }
}