using _0_Framework.Domain.Common;
using ShopManagment.Domain.ProductAgg.ProductImageAgg;
using ShopManagment.Domain.ProductAgg.ProductFeatureAgg;
using ShopManagment.Domain.ProductCategoryAgg.ProductCategoryTypeAgg;
using ShopManagment.Domain.ProductCategoryAgg.ProductCategoryBrandAgg;

namespace ShopManagment.Domain.ProductAgg.ProductItemAgg
{
    public class ProductItem : EntityBase, IComparable<Guid>, IEquatable<Guid>
    {
        public long Price { get; private set; }
        
        public string Name { get; private set; }
       
        public string Slug { get; private set; }
        
        public string Keywords { get; private set; }
        
        public string PictureAlt { get; private set; }

        public GenderType Gender { get; private set; }
        
        public string Description { get; private set; }

        public int AvailableStock { get; private set; }
        
        public string PictureTitle { get; private set; }
        
        public int RestockThreshold { get; private set; }
        
        public int MaxStockThreshold { get; private set; }
        
        public string MetaDescription { get; private set; }

        public Guid ProductCategoryTypeId { get; private set; }

        public ProductCategoryType ProductCategoryType { get; private set; }

        public Guid ProductCategoryBrandId { get; private set; }

        public ProductCategoryBrand ProductCategoryBrand { get; private set; }

        public ICollection<ProductImage> ProductItemImages { get; private set; }

        public ICollection<ProductFeature> ProductItemFeatures { get; private set; }

        public ProductItem(long price,
                           string name,
                           string slug,
                           string keywords,
                           string pictureAlt,
                           string description,
                           int availableStock,
                           string pictureTitle,
                           int restockThreshold,
                           int maxStockThreshold,
                           string metaDescription,
                           Guid productCategoryTypeId,
                           Guid productCategoryBrandId,
                           ICollection<ProductImage> productItemImages,
                           ICollection<ProductFeature> productItemFeatures)
        {
            Price = price;
            Name = name;
            Slug = slug;
            Keywords = keywords;
            PictureAlt = pictureAlt;
            Description = description;
            AvailableStock = availableStock;
            PictureTitle = pictureTitle;
            RestockThreshold = restockThreshold;
            MaxStockThreshold = maxStockThreshold;
            MetaDescription = metaDescription;
            ProductCategoryTypeId = productCategoryTypeId;
            ProductCategoryBrandId = productCategoryBrandId;
            ProductItemImages = productItemImages;
            ProductItemFeatures = productItemFeatures;
        }

        public void Update(long price,
                           string name,
                           string slug,
                           string keywords,
                           string pictureAlt,
                           string description,
                           int availableStock,
                           string pictureTitle,
                           int restockThreshold,
                           int maxStockThreshold,
                           string metaDescription,
                           Guid productCategoryTypeId,
                           Guid productCategoryBrandId,
                           ICollection<ProductImage> productItemImages,
                           ICollection<ProductFeature> productItemFeatures)
        {
            Price = price;
            Name = name;
            Slug = slug;
            Keywords = keywords;
            PictureAlt = pictureAlt;
            Description = description;
            AvailableStock = availableStock;
            PictureTitle = pictureTitle;
            RestockThreshold = restockThreshold;
            MaxStockThreshold = maxStockThreshold;
            MetaDescription = metaDescription;
            ProductCategoryTypeId = productCategoryTypeId;
            ProductCategoryBrandId = productCategoryBrandId;
            ProductItemImages = productItemImages;
            ProductItemFeatures = productItemFeatures;
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

    public enum GenderType
    {
        Unknown = 0,

        Men = 1,

        Women = 2,
    }
}