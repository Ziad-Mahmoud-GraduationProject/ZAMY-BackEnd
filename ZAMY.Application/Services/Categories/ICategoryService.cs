using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.Categories
{
    public interface ICategoryService
    {
        Category Add(Category category);
        
        Category Update(int id,Category category);

        IEnumerable<Category>? GetAll();
        
        Category? GetById(int id);

        IEnumerable<Category>? GetByName(string name);

    }
}
