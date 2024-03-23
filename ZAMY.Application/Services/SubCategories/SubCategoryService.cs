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
        public IEnumerable<SubCategory> GetAll()=> _unitOfWork.SubCategories.GetAll();
        public PagedList<SubCategory> GetAllWithPagination(PaginationParameters paginationParameters)
        {
            return PagedList<SubCategory>.GetPagedList(_unitOfWork.SubCategories.GetAll(),paginationParameters.PageNumber,paginationParameters.PageSize);
        }
        public SubCategory GetById(int id)=> _unitOfWork.SubCategories.GetById(id);

        public IEnumerable<SubCategory> GetCategoryName(string subcategoryname)
        {
            var subcategories= _unitOfWork.SubCategories.GetAll();
            return subcategories
                .Where(subcategory=>subcategory.Name.ToLower()
                .Contains(subcategoryname.ToLower()));  
        }
        public SubCategory Add(SubCategory subcategory)
        {
            _unitOfWork.SubCategories.Add(subcategory);
            _unitOfWork.Complete();
            return subcategory;
        }
        public SubCategory Update(SubCategory subcategory)
        {
            _unitOfWork.SubCategories.Update(subcategory);
            _unitOfWork.Complete();
            return subcategory;
        }
        public SubCategory Delete(SubCategory subcategory)
        {
            _unitOfWork.SubCategories.Remove(subcategory);
            _unitOfWork.Complete();
            return subcategory;
        }
    }
}
