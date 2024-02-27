using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.MainCategories
{
    public interface IMainCategoryService
    {
        IEnumerable<MainCategory> GetAll();
        MainCategory GetById(int id);
        MainCategory GetCategoryName(string maincategoryName);
        MainCategory Add(MainCategory maincategory);
        MainCategory Update(MainCategory maincategory);
        MainCategory Delete(MainCategory maincategory);
    }
}
