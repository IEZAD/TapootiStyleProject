using AutoMapper;
using ShopManagment.Domain.ProductCategoryAgg.ProductCategoryTypeAgg;
using ShopManagment.Application.Contracts.ProductCategory.ProductCategoryType;

namespace ShopManagment.Configuration.MappingProfile
{
    public class ProductCategoryTypeMappingProfile : Profile
    {
        public ProductCategoryTypeMappingProfile()
        {
            CreateMap<ProductCategoryType, ProductCategoryTypeViewModel>().ReverseMap();

            CreateMap<ProductCategoryType, ProductCategoryTypeListViewModel>()
                .ForMember(dest => dest.SubTypeCount, option => option.MapFrom(src => src.SubType.Count));

            CreateMap<MenuItemViewModel, ProductCategoryType> ().ReverseMap()
                .ForMember(dest => dest.Name, option => option.MapFrom(src => src.Type))
                .ForMember(dest => dest.SubMenu, option => option.MapFrom(src => src.SubType))
                .ForMember(dest => dest.ParentId, option => option.MapFrom(src => src.ParentProductCategoryTypeId));
        }
    }
}