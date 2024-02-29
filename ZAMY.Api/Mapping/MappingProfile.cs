namespace ZAMY.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MainCategory,CreateMainCategoryDto>().ReverseMap();
            CreateMap<MainCategory,MainCategoryDto>();
        }
    }
}
