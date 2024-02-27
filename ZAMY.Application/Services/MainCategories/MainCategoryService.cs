using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.MainCategories
{
    public class MainCategoryService(IUnitOfWork _uitOfWork) : IMainCategoryService
    {
        public IEnumerable<MainCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public MainCategory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public MainCategory GetCategoryName(string maincategoryName)
        {
            throw new NotImplementedException();
        }
        public MainCategory Add(MainCategory maincategory)
        {
            throw new NotImplementedException();
        }
        public MainCategory Update(MainCategory maincategory)
        {
            throw new NotImplementedException();
        }

        public MainCategory Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
