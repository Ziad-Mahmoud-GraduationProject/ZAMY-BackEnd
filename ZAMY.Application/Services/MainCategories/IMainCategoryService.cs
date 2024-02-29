namespace ZAMY.Application.Services.MainCategories
{
    public interface IMainCategoryService
    {
        IEnumerable<MainCategory> GetAll();
        MainCategory GetById(int id);
        MainCategory GetCategoryName(string maincategoryName);
        MainCategory Add(MainCategory maincategory);
        MainCategory Update(MainCategory maincategory);
        MainCategory ToggelStatus(MainCategory maincategory);
    }
}
