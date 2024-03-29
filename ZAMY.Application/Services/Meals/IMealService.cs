namespace ZAMY.Application.Services.Meals
{
    public interface IMealService
    {
        PagedList<Meal> GetAll(PaginationParameters paginationParameters);
        Meal GetById(int id);
        Meal Add(Meal meal);
        Meal Update(Meal meal);
        Meal Delete(Meal meal);
    }
}
