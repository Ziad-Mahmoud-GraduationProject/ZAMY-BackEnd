
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
    public class MappingProfileOrder : Profile
    {
        public MappingProfileOrder()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<CreateOrder,Order>();
        }
    }
    public class MappingProfileReview : Profile
    {
        public MappingProfileReview()
        {
            CreateMap<Review, ReviewDto>();
            CreateMap<CreateReview, Review>();
        }
    }
}
