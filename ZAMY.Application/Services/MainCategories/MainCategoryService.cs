using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAMY.Domain.Entities;

namespace ZAMY.Application.Services.MainCategories
{
    public class MainCategoryService(IUnitOfWork _unitOfWork) : IMainCategoryService
    {
        public IEnumerable<MainCategory> GetAll()=> _unitOfWork.MainCategories.GetAll();
 
        public MainCategory GetById(int id)=> _unitOfWork.MainCategories.GetById(id);

        public IEnumerable<MainCategory> GetCategoryName(string maincategoryName)
        {
            var maincategories = _unitOfWork.MainCategories.GetAll();
            return maincategories
                .Where(maincategory => maincategory.Name.ToLower()
                .Contains(maincategoryName.ToLower()));
        }
        public MainCategory Add(MainCategory maincategory)
        {
            _unitOfWork.MainCategories.Add(maincategory);
            _unitOfWork.Complete();
            return maincategory;
        }
        public MainCategory Update(MainCategory maincategory)
        {

            _unitOfWork.MainCategories.Update(maincategory);
            _unitOfWork.Complete();
            return maincategory;
        }

        public MainCategory Delete(MainCategory maincategory)
        {
            _unitOfWork.MainCategories.Remove(maincategory);
            _unitOfWork.Complete();
            return maincategory;
        }
    }
}
