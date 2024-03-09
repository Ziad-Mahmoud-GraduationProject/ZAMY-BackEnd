using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.Orders
{
    internal class OrderService(IUnitOfWork _unitOfWork) : IOrderService
    {
        public IEnumerable<Order> GetAll()=>_unitOfWork.Orders.GetAll();

        public Order GetById(int id) => _unitOfWork.Orders.GetById(id);    
        public Order Add(Order order)
        {
            _unitOfWork.Orders.Add(order);
            _unitOfWork.Complete();
            return order;
        }
        public Order Update(Order order)
        {
            _unitOfWork.Orders.Update(order);
            _unitOfWork.Complete();
            return order;
        }
        public Order Delete(Order order)
        {
            _unitOfWork.Orders.Remove(order);
            _unitOfWork.Complete();
            return order;
        } 
    }
}
