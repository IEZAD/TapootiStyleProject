using _0_Framework.Domain.Common;
using ShopManagment.Domain.ProductAgg.ProductItemAgg;

namespace ShopManagment.Domain.ProductAgg.ProductImageAgg
{
    public class ProductImage : EntityBase, IComparable<Guid>, IEquatable<Guid>
    {
        public bool IsDefault { get; private set; }

        public string ImageUrl { get; private set; }

        public Guid ProductItemId { get; private set; }

        public ProductItem ProductItem { get; private set; }

        public ProductImage(bool isDefault, string imageUr)
        {
            ImageUrl = imageUr;
            IsDefault = isDefault;
        }

        public void Update(bool isDefault, string imageUr)
        {
            ImageUrl = imageUr;
            IsDefault = isDefault;
        }

        public int CompareTo(Guid other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Guid other)
        {
            throw new NotImplementedException();
        }
    }
}