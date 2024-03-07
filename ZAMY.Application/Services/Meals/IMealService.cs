namespace ZAMY.Application.Services.Meals
{
    public interface IMealService
    {
        IEnumerable<Meal> GetAll();
        Meal GetById(int id);
        bool IsExists(int id);
        Meal Add(Meal meal);
        Meal Update(Meal meal);
        Meal? ToggleStatus(int id);
    }
}
