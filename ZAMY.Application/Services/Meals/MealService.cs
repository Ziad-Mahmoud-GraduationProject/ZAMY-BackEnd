
using ZAMY.Domain.Entities;

namespace ZAMY.Application.Services.Meals
{
    public class MealService(IUnitOfWork _unitOfWork) : IMealService
    {
        public PagedList<Meal> GetAll(PaginationParameters paginationParameters)
        {
            return PagedList<Meal>
                .GetPagedList(_unitOfWork.Meals.GetAll(),
                paginationParameters.PageNumber,
                paginationParameters.PageSize);
        }

        public Meal GetById(int id)=> _unitOfWork.Meals.GetById(id);
        public Meal Add(Meal meal)
        {
            _unitOfWork.Meals.Add(meal);
            _unitOfWork.Complete();
            return meal;
        }
        public Meal Update(Meal meal)
        {
            _unitOfWork.Meals.Update(meal);
            _unitOfWork.Complete();
            return meal;
        }
        public Meal Delete(Meal meal)
        {
            _unitOfWork.Meals.Remove(meal);
            _unitOfWork.Complete();
            return meal;
        }
    }
}
