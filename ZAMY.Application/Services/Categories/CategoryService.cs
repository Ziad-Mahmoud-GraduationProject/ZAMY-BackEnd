using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.Categories
{
    public class CategoryService(IUnitOfWork _unitOfWork) : ICategoryService
    {
        public Category Add(Category category)
        {
            _unitOfWork.Categories.Add(category);

            _unitOfWork.Complete();

            return category;
        }

        public IEnumerable<Category>? GetAll()
        {
            return _unitOfWork.Categories.GetAll();
        }

        public Category? GetById(int id)
        {
            return _unitOfWork.Categories.GetById(id);
        }

        public IEnumerable<Category>? GetByName(string name)
        {
            return _unitOfWork.Categories.FindAll(c => c.Name.ToLower().Contains(name),OrderBy.Ascending);
        }

        public Category Update(int id,Category category)
        {
             _unitOfWork.Categories.Update(category);

            return category;
        }
    }
}
