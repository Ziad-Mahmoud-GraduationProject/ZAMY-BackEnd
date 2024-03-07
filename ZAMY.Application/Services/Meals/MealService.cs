
namespace ZAMY.Application.Services.Meals
{
    public class MealService(IUnitOfWork _unitOfWork) : IMealService
    {
        /*IEnumerable<Meal>GetAll()
        {

        }
        public Meal GetById(int id)
        {
            return  _unitOfWork.Meals.Find(m => m.Id == id);
        }


        public Meal Add(Meal meal)
        {
           /* meal.CreatedById = createdById;

            meal.MainCategoryId = mainCategoryId;

            meal.SubCategoryId = subCategoryId;


            _unitOfWork.Meals.Add(meal);
            _unitOfWork.Complete();

            return meal;
        }

        public Meal Update(Meal meal)
        {
           /* meal.UpdatedById = updatedById;
            meal.UpdateOn = DateTime.Now;

            meal.MainCategoryId = mainCategoryId;
            meal.SubCategoryId = subCategoryId;

            _unitOfWork.Complete();

            return meal;
        }

        public Meal ToggleStatus(int id)
        {
            var meal = GetById(id);

            if (meal is null)
                return null;

            meal.IsDeleted = !meal.IsDeleted;
           // meal.UpdatedById = updatedById;
            meal.UpdateOn = DateTime.Now;

            _unitOfWork.Complete();

            return meal;
        }*/
        public IEnumerable<Meal> GetAll()
        {
            return _unitOfWork.Meals.GetAll();
        }

        public Meal GetById(int id)
        {
           // var m= _unitOfWork.Meals.IsExists(x => x.KitchenId == id);
            return _unitOfWork.Meals.GetById(id);
            
        }
        public Meal Add(Meal meal)
        {
            _unitOfWork.Meals.Add(meal);
            _unitOfWork.Complete();
            return meal;
        }
        public Meal Update(Meal meal)
        {
            throw new NotImplementedException();
        }
        public Meal? ToggleStatus(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
