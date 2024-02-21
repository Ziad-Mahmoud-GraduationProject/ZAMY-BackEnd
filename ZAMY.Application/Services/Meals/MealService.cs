namespace ZAMY.Application.Services.Meals
{
    public class MealService(IUnitOfWork _unitOfWork) : IMealService
    {
        public Meal? GetById(int id)
        {
            return  _unitOfWork.Meals.Find(m => m.Id == id);
        }


        public Meal Add(Meal meal, int mainCategoryId, int subCategoryId, string createdById)
        {
            meal.CreatedById = createdById;

            meal.MainCategoryId = mainCategoryId;

            meal.SubCategoryId = subCategoryId;


            _unitOfWork.Meals.Add(meal);
            _unitOfWork.Complete();

            return meal;
        }

        public Meal Update(Meal meal, int mainCategoryId, int subCategoryId, string updatedById)
        {
            meal.UpdatedById = updatedById;
            meal.UpdateOn = DateTime.Now;

            meal.MainCategoryId = mainCategoryId;
            meal.SubCategoryId = subCategoryId;

            _unitOfWork.Complete();

            return meal;
        }

        public Meal? ToggleStatus(int id, string updatedById)
        {
            var meal = GetById(id);

            if (meal is null)
                return null;

            meal.IsDeleted = !meal.IsDeleted;
            meal.UpdatedById = updatedById;
            meal.UpdateOn = DateTime.Now;

            _unitOfWork.Complete();

            return meal;
        }

    }
}
