using ZAMY.Application.Common.Interfaces;

namespace ZAMY.Application.Services.Choices
{
    public class ChoicesServices (IUnitOfWork _unitOfWork) : IChoicesServices
    {
        public Choice? GetById(int id)
        {
            return _unitOfWork.Choices.GetById(id);
        }

        public IEnumerable<Choice>? GetAll(int Mealid)
        {
            return _unitOfWork.Choices.FindAll(predicate: e => e.MealId == Mealid, orderBy: e => e.Name, orderByDirection: OrderBy.Ascending);
        }

        public Choice? Add(Choice choice)
        {
            _unitOfWork.Choices.Add(choice);
            return _unitOfWork.Complete() > 0 ? choice : null;
        }

        public Choice? Update(int id, Choice updatedChoice)
        {
            var existingChoices = _unitOfWork.Choices.GetById(id);
            if (existingChoices != null)
            {
                existingChoices.Name = updatedChoice.Name;

                _unitOfWork.Choices.Update(existingChoices);
                return _unitOfWork.Complete() > 0 ? existingChoices : null;

            }

            return null;

        }

        public bool Delete(int id)
        {
            var choices = _unitOfWork.Choices.GetById(id);
            if (choices != null)
            {
                _unitOfWork.Choices.Remove(choices);
                return _unitOfWork.Complete() > 0 ? true : false;
            }

            return false;
        }

        public bool ToggleStatus(int id)
        {
            var choice = GetById(id);

            if(choice is not null)
            {
                choice.IsActive = !choice.IsActive;

                _unitOfWork.Choices.Update(choice);
                return _unitOfWork.Complete() > 0 ? true : false;
            }
            return false;

        }
    }
}
