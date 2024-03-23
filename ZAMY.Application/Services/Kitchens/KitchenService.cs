using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.Kitchens
{
    public class KitchenService(IUnitOfWork _unitOfWork) : IKitchenService
    {
        public IEnumerable<Kitchen>? GetAll()
        {
            return null;
             return _unitOfWork.Kitchens.GetAll(withNoTracking:false);

        }

        public Kitchen? GetById(int id)
        {
            return  _unitOfWork.Kitchens.GetById(id);
        }

        public IEnumerable<Kitchen> GetKitchenName(string kitchenName)
        {
            return _unitOfWork.Kitchens.FindAll(k => k.Name.ToLower().Contains(kitchenName.ToLower()),null, OrderBy.Ascending);
            
        }

        public bool IsExists(int id)
        {
           return _unitOfWork.Kitchens.IsExists(k=>k.Id==id);
        }
    }
}
