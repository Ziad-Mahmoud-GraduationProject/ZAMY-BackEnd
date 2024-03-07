using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.CartItems
{
    public class CartItemService(IUnitOfWork _unitOfWork,
        IMealService _mealService) : ICartItemService
    {
        public IEnumerable<CartItem> GetAll() => _unitOfWork.CartItems.GetAll();

        public CartItem GetById(int id) => _unitOfWork.CartItems.GetById(id);


        public decimal GetPrice(int id)
        {
            var cartItem= _unitOfWork.CartItems.Find(c => c.Id == id,["Meal"]);
            var price= cartItem.Quantity *cartItem.Meal.Price;
            return price;
        }

        public CartItem Update(CartItem item)
        {
            _unitOfWork.CartItems.Update(item);
            _unitOfWork.Complete();
            return item;
        }
        public CartItem Add(CartItem item)
        {
           _unitOfWork.CartItems.Add(item);
            _unitOfWork.Complete(); 
            return item;
        }

        public CartItem Delete(CartItem item)
        {
            _unitOfWork.CartItems.Remove(item);
            _unitOfWork.Complete();
            return item;
        }

      
    }
}
