using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.SubCategories
{
    public interface ISubCategoryService
    {

        IEnumerable<SubCategory> GetAll();
        SubCategory GetById(int id);
        IEnumerable<SubCategory> GetCategoryName(string subcategoryname);
        SubCategory Add(SubCategory subcategory);
        SubCategory Update(SubCategory subcategory);
        SubCategory Delete(SubCategory subcategory);
    }
}
