using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Entities
{
    public class CustomerMeal
    {
        public int Id { get;set; }
        public int CustomerId { get; set; }
        public int MealId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Meal Meal { get; set; }
    }
}
