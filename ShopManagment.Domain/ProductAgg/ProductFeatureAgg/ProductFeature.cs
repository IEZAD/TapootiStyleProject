using _0_Framework.Domain.Common;
using ShopManagment.Domain.ProductAgg.ProductItemAgg;

namespace ShopManagment.Domain.ProductAgg.ProductFeatureAgg
{
    public class ProductFeature : EntityBase, IComparable<Guid>, IEquatable<Guid>
    {
        public string Key { get; private set; }

        public string Value { get; private set; }

        public string Group { get; private set; }

        public Guid ProductId { get; private set; }

        public ProductItem Product { get; private set; }

        public ProductFeature(string key, string value, string group)
        {
            Key = key;
            Value = value;
            Group = group;
        }

        public void Update(string key, string value, string group)
        {
            Key = key;
            Value = value;
            Group = group;
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