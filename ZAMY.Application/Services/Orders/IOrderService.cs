using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.Orders
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        Order Add(Order order);
        Order Update(Order order);
        Order Delete(Order order);
    }
}
