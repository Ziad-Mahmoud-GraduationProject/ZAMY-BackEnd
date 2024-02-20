using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 0;
        public int CartId { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public Cart Cart { get; set; }
    }
}
