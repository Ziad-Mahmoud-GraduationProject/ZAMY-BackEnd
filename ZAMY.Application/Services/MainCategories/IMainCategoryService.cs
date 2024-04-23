namespace ZAMY.Application.Services.MainCategories
{
    public interface IMainCategoryService
    {
        IEnumerable<MainCategory> GetAll(PaginationParameters paginationParameters);
        MainCategory GetById(int id);
        IEnumerable<MainCategory> GetCategoryName(string maincategoryName, PaginationParameters paginationParameters);
        MainCategory? Add1(MainCategory maincategory, IFormFile img);
        MainCategory Add(MainCategory maincategory);
        MainCategory Update(MainCategory maincategory);
        MainCategory? Update1(int id,MainCategory maincategory, IFormFile img);
        bool Delete(int id);
    }
}
