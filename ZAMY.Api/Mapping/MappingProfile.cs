using AutoMapper;
using ZAMY.Api.Dtos.CartItem.incommig;
using ZAMY.Api.Dtos.CartItem.outcomming;
using ZAMY.Api.Dtos.Kitchen.incoming;
using ZAMY.Api.Dtos.Kitchen.outcoming;

namespace ZAMY.Api.Mapping
{
    public class MappingProfileMainCategory : Profile
    {
        public MappingProfileMainCategory()
        {
            CreateMap<MainCategory, CreateMainCategoryDto>().ReverseMap();
            CreateMap<MainCategory, MainCategoryDto>();
        }
    }
    public class MappingProfileKitchen : Profile
    {
        public MappingProfileKitchen()
        { 
            CreateMap<CreateKitchenDto, Kitchen>();
            CreateMap<Kitchen, KitchenDto>();  
        }
    }
    public class MappingProfileCartItem : Profile
    {
        public MappingProfileCartItem()
        {
            CreateMap<CreateCartItem, CartItem>();
            CreateMap<CartItem, CartItemDto>();
        }
    }
}
