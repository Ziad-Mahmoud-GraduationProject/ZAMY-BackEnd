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
        PagedList<SubCategory> GetAll(PaginationParameters paginationParameters);
        SubCategory GetById(int id);
        IEnumerable<SubCategory> GetCategoryName(string subcategoryname);
        SubCategory? Add(SubCategory subcategory,IFormFile img);
        SubCategory? Update(int id,SubCategory subcategory,IFormFile img);
        bool Delete(int id);
    }
}
