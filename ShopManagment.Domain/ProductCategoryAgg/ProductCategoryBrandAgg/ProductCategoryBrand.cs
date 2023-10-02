using _0_Framework.Domain.Common;

namespace ShopManagment.Domain.ProductCategoryAgg.ProductCategoryBrandAgg
{
    public class ProductCategoryBrand : EntityBase, IComparable<Guid>, IEquatable<Guid>
    {
        public string Brand { get; private set; }

        public ProductCategoryBrand(string brand)
        {
            Brand = brand;
        }

        public void Update(string brand)
        {
            Brand = brand;
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