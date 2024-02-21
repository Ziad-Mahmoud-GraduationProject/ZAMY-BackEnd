namespace ZAMY.Application.Services.Meals
{
    public interface IMealService
    {
        Meal? GetById(int id);
        Meal Add(Meal meal, int mainCategory, int subCategory, string createdById);
        Meal Update(Meal meal, int mainCategory, int subCategory, string updatedById);
        Meal? ToggleStatus(int id, string updatedById);
    }
}
