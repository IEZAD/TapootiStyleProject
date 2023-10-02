using _0_Framework.Domain.Common;

namespace ShopManagment.Domain.ProductCategoryAgg.ProductCategoryTypeAgg
{
    public class ProductCategoryType : EntityBase, IComparable<Guid>, IEquatable<Guid>
    {
        public string Type { get; private set; }

        public int OrderId { get; private set; }

        public Guid? ParentProductCategoryTypeId { get; private set; }

        public ProductCategoryType? ParentProductCategoryType { get; private set; }

        public ICollection<ProductCategoryType>? SubType { get; private set; }

        public ProductCategoryType(string type, int orderId, Guid? parentProductCategoryTypeId)
        {
            Type = type;
            OrderId = orderId;
            ParentProductCategoryTypeId = parentProductCategoryTypeId;
        }

        public void Update(string type, int orderId, Guid? parentProductCategoryTypeId)
        {
            Type = type;
            OrderId = orderId;
            ParentProductCategoryTypeId = parentProductCategoryTypeId;
        }

        public bool Equals(Guid other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Guid other)
        {
            throw new NotImplementedException();
        }
    }
}