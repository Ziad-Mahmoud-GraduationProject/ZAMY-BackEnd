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
        public IEnumerable<MainCategory> GetAll()
        {
            return _unitOfWork.MainCategories.GetAll();
        }

        public MainCategory GetById(int id)
        {
            return _unitOfWork.MainCategories.Find(m => m.Id == id);
        }

        public MainCategory GetCategoryName(string maincategoryName)
        {
            throw new NotImplementedException();
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

        public MainCategory ToggelStatus(MainCategory maincategory)
        {
            maincategory.IsDeleted = !maincategory.IsDeleted;
            _unitOfWork.Complete();
            return maincategory;
        }
    }
}
