namespace ZAMY.Api.Mapping
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Meal, MealDto>();
            CreateMap<CreateMealDTO, Meal>();

            CreateMap<MainCategory, CreateMainCategoryDto>().ReverseMap();
            CreateMap<MainCategory, MainCategoryDto>();

            CreateMap<CreateKitchenDto, Kitchen>();
            CreateMap<Kitchen, KitchenDto>();

            CreateMap<CreateCartItem, CartItem>();
            CreateMap<CartItem, CartItemDto>();

            CreateMap<Order, OrderDto>();
            CreateMap<CreateOrder,Order>();

            CreateMap<Review, ReviewDto>();
            CreateMap<CreateReview, Review>();


            CreateMap<CreateAdditionDto, Addition>();
            CreateMap<EditAdditionDto, Addition>();
            CreateMap<Addition, AdditionDto>()
                .ForMember(dest => dest.MealName, opt => opt.MapFrom(src => src.Meal.Name));

        }
    }

}
