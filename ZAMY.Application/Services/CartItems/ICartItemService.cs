using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Services.CartItems
{
    public interface ICartItemService
    {
        IEnumerable<CartItem> GetAll();
        CartItem GetById(int id);
        decimal GetPrice(int id);
        CartItem Add(CartItem item);
        CartItem Update(CartItem item);
        CartItem Delete(CartItem item);

    }
}
