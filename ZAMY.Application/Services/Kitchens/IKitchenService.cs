using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.Kitchens
{
    public interface IKitchenService
    {
        IEnumerable<Kitchen>? GetAll();
        Kitchen? GetById(int id);
        bool IsExists(int id);
        IEnumerable<Kitchen> GetKitchenName(string kitchenName);
    }
}
