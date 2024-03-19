using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAMY.Application.Common.Helper;

namespace ZAMY.Application.Services.SubCategories
{
    public interface ISubCategoryService
    {

        IEnumerable<SubCategory> GetAll();
        PagedList<SubCategory> GetAllWithPagination(PaginationParameters paginationParameters);
        SubCategory GetById(int id);
        IEnumerable<SubCategory> GetCategoryName(string subcategoryname);
        SubCategory Add(SubCategory subcategory);
        SubCategory Update(SubCategory subcategory);
        SubCategory Delete(SubCategory subcategory);
    }
}
