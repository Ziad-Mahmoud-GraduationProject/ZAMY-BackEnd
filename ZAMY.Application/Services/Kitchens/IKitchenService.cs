using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.Kitchens
{
    public interface IKitchenService
    {
        IEnumerable<Kitchen> GetAll(PaginationParameters paginationParameters);
        Kitchen? GetById(int id);
        bool IsExists(int id);
        IEnumerable<Kitchen> GetKitchenName(string kitchenName, PaginationParameters paginationParameters);
        Kitchen Add(Kitchen kitchen);
        Kitchen Update(Kitchen kitchen);
    }
}
