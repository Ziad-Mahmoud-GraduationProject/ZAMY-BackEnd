using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAMY.Application.Common.Helper;
using ZAMY.Domain.Entities;

namespace ZAMY.Application.Services.MainCategories
{
    public class MainCategoryService(IUnitOfWork _unitOfWork) : IMainCategoryService
    {
        // public IEnumerable<MainCategory> GetAll()=> _unitOfWork.MainCategories.GetAll();
        public IEnumerable<MainCategory> GetAll(PaginationParameters paginationParameters)
        {
            return PagedList<MainCategory>
                .GetPagedList(_unitOfWork.MainCategories.GetAll(),
                paginationParameters.PageNumber,
                paginationParameters.PageSize);
        }


        public MainCategory GetById(int id)=> _unitOfWork.MainCategories.GetById(id);

        public IEnumerable<MainCategory> GetCategoryName(string maincategoryName, PaginationParameters paginationParameters)
        {
            var maincategories = _unitOfWork.MainCategories.GetAll()
                .Where(maincategory => maincategory.Name.ToLower()
                .Contains(maincategoryName.ToLower()));
            return PagedList<MainCategory>
                .GetPagedList(maincategories,
            paginationParameters.PageNumber,
                paginationParameters.PageSize);
        }
        public MainCategory? Add1(MainCategory maincategory, IFormFile img)
        {
            maincategory.ImgUrl = FileHelper.UploadImageAsync(img);
            _unitOfWork.MainCategories.Add(maincategory);

            return _unitOfWork.Complete() > 0 ? maincategory : null;
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
        public MainCategory? Update1(int id, MainCategory maincategory, IFormFile img)
        {
            var addmaincategory = _unitOfWork.MainCategories.GetById(id);

            if (addmaincategory is not null)
            {
                addmaincategory.Name = maincategory.Name;

                if (img is not null)
                {
                    var oldPath = addmaincategory.ImgUrl;
                    addmaincategory.ImgUrl = FileHelper.UploadImageAsync(img);

                    File.Delete(oldPath);
                }
                _unitOfWork.MainCategories.Update(addmaincategory);
                return _unitOfWork.Complete() > 0 ? addmaincategory : null;
            }
           return null;
        }
        public bool Delete(int id)
        {
            var maincategory = _unitOfWork.MainCategories.GetById(id);
            if (maincategory is not null)
            {
                _unitOfWork.MainCategories.Remove(maincategory);
                return _unitOfWork.Complete() > 0 ? true : false;
            }

            return false;
        }
    }
}
