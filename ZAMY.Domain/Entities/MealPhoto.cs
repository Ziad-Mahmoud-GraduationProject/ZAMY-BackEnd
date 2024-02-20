using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Entities
{
    public class MealPhoto
    {
        public string URL_Photo { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get;set; }
    }
}
