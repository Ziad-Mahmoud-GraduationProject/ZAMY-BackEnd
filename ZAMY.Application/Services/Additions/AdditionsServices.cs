namespace ZAMY.Application.Services.Additions
{
    public class AdditionsServices(IUnitOfWork _unitOfWork) :IAdditionsServices
    {
        public Addition? GetById(int id)
        {
            return  _unitOfWork.Addition.GetById(id);
        }

        public IEnumerable<Addition>? GetAll(int Mealid)
        {
            return  _unitOfWork.Addition.FindAll(predicate: e => e.MealId == Mealid,orderBy: e => e.Price ,orderByDirection: OrderBy.Ascending);
        }

        public Addition? Add(Addition addition,IFormFile img)
        {
            addition.ImgUrl = FileHelper.UploadImageAsync(img);

            _unitOfWork.Addition.Add(addition);
            return _unitOfWork.Complete() > 0 ? addition : null;
        }

        public Addition? Update(int id, Addition updatedAddition,IFormFile img)
        {
            var existingAddition =  _unitOfWork.Addition.GetById(id);
            if (existingAddition != null)
            {
                existingAddition.Name = updatedAddition.Name;
                existingAddition.Description = updatedAddition.Description;
                existingAddition.Price = updatedAddition.Price;
                existingAddition.IsAvailable = updatedAddition.IsAvailable;
                existingAddition.ImgUrl = updatedAddition.ImgUrl;
                existingAddition.MealId = updatedAddition.MealId;

                if (img is not null)
                {
                    var oldPath = existingAddition.ImgUrl;
                    existingAddition.ImgUrl = FileHelper.UploadImageAsync(img);
                    
                    File.Delete(oldPath);
                }

                _unitOfWork.Addition.Update(existingAddition);
                return _unitOfWork.Complete() > 0 ? existingAddition : null;

            }

            return null;

        }

        public bool Delete(int id)
        {
            var addition = _unitOfWork.Addition.GetById(id);
            if (addition != null)
            {
                _unitOfWork.Addition.Remove(addition);
                return _unitOfWork.Complete() > 0 ? true : false;
            }

            return false;
        }
    }
}
