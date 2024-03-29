namespace ZAMY.Application.Services.MainCategories
{
    public interface IMainCategoryService
    {
        IEnumerable<MainCategory> GetAll(PaginationParameters paginationParameters);
        MainCategory GetById(int id);
        IEnumerable<MainCategory> GetCategoryName(string maincategoryName, PaginationParameters paginationParameters);
        MainCategory Add(MainCategory maincategory);
        MainCategory Update(MainCategory maincategory);
        MainCategory ToggelStatus(MainCategory maincategory);
    }
}
