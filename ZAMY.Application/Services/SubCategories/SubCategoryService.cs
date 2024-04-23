using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAMY.Application.Common.Helper;

namespace ZAMY.Application.Services.SubCategories
{
    public class SubCategoryService(IUnitOfWork _unitOfWork) : ISubCategoryService
    {
      
        public PagedList<SubCategory> GetAll(PaginationParameters paginationParameters)
        {
            return PagedList<SubCategory>
                .GetPagedList(_unitOfWork.SubCategories.GetAll()
                ,paginationParameters
                .PageNumber,paginationParameters.PageSize);
        }
        public SubCategory GetById(int id)=> _unitOfWork.SubCategories.GetById(id);

        public IEnumerable<SubCategory> GetCategoryName(string subcategoryname)
        {
            var subcategories= _unitOfWork.SubCategories.GetAll();
            return subcategories
                .Where(subcategory=>subcategory.Name.ToLower()
                .Contains(subcategoryname.ToLower()));  
        }
        public SubCategory? Add(SubCategory subcategory, IFormFile img)
        {
           subcategory.ImgUrl = FileHelper.UploadImageAsync(img);
            _unitOfWork.SubCategories.Add(subcategory);

            return _unitOfWork.Complete() > 0 ? subcategory : null;
        }
        public SubCategory? Update(int id, SubCategory subcategory, IFormFile img)
        {
            var addsubcategory = _unitOfWork.SubCategories.GetById(id);

            if (addsubcategory is not null)
            {
                addsubcategory.Name = subcategory.Name;

                if (img is not null)
                {
                    var oldPath = addsubcategory.ImgUrl;
                    addsubcategory.ImgUrl = FileHelper.UploadImageAsync(img);

                    File.Delete(oldPath);
                }
                _unitOfWork.SubCategories.Update(addsubcategory);
                return _unitOfWork.Complete() > 0 ? addsubcategory : null;
            }
            return null;
        }
        public bool Delete(int id)
        {
            var subcategory = _unitOfWork.SubCategories.GetById(id);
            if (subcategory is not null)
            {
                _unitOfWork.SubCategories.Remove(subcategory);
                return _unitOfWork.Complete() > 0 ? true : false;
            }

            return false;
        }
    }
}
