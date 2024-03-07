using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.Kitchens
{
    public class KitchenService(IUnitOfWork _unitOfWork) : IKitchenService
    {
        public IEnumerable<Kitchen> GetAll()
        {
             return _unitOfWork.Kitchens.GetAll();

        }

        public Kitchen GetById(int id)
        {
            return _unitOfWork.Kitchens.GetById(id);
        }

        public IEnumerable<Kitchen> GetKitchenName(string kitchenName)
        {
            var maincategories = _unitOfWork.Kitchens.GetAll();
            return maincategories
                .Where(maincategory => maincategory.Name.ToLower()
                .Contains(kitchenName.ToLower()));
        }
        public Kitchen Add(Kitchen kitchen)
        {
            _unitOfWork.Kitchens.Add(kitchen);
            _unitOfWork.Complete();
            return kitchen;
        }
        public Kitchen Update(Kitchen kitchen)
        {
            _unitOfWork.Kitchens.Update(kitchen);
            _unitOfWork.Complete();
            return kitchen;
        }
            public Kitchen ToggelStatus(Kitchen kitchen)
        {
            _unitOfWork.Kitchens.Remove(kitchen);
            _unitOfWork.Complete();
            return kitchen;
        }

        public bool IsExists(int id)
        {
           return _unitOfWork.Kitchens.IsExists(k=>k.Id==id);
        }
    }
}
