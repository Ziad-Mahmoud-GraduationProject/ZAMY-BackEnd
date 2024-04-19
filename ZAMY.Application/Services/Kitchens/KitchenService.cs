using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.Kitchens
{
    public class KitchenService(IUnitOfWork _unitOfWork) : IKitchenService
    {
        /* public IEnumerable<Kitchen>? GetAll()
         {
             return null;
              return _unitOfWork.Kitchens.GetAll(withNoTracking:false);

         }*/
       public IEnumerable<Kitchen> GetAll(PaginationParameters paginationParameters)
        {
            return PagedList<Kitchen>
                .GetPagedList(_unitOfWork.Kitchens.GetAll(),
                paginationParameters.PageNumber,
                paginationParameters.PageSize);
        }

        public Kitchen? GetById(int id)
        {
            return  _unitOfWork.Kitchens.GetById(id);
        }

        /*  public IEnumerable<Kitchen> GetKitchenName(string kitchenName)
          {
              var kitchens= _unitOfWork.Kitchens.FindAll(k => k.Name.ToLower().Contains(kitchenName.ToLower()), null, OrderBy.Ascending);
              return _unitOfWork.Kitchens.FindAll(k => k.Name.ToLower().Contains(kitchenName.ToLower()),null, OrderBy.Ascending);

          }*/
        public IEnumerable<Kitchen> GetKitchenName(string kitchenName, PaginationParameters paginationParameters)
        {
            var kitchens = _unitOfWork.Kitchens
                .FindAll(k => k.Name.ToLower()
            .Contains(kitchenName
            .ToLower()), null, OrderBy.Ascending);
            return PagedList<Kitchen>
                 .GetPagedList(kitchens,
                 paginationParameters.PageNumber,
                 paginationParameters.PageSize);

        }

        public bool IsExists(int id)
        {
           return _unitOfWork.Kitchens.IsExists(k=>k.Id==id);
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
    }
}
