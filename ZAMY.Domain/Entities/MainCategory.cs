using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Entities
{
    public class MainCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Meal> Meals { get; set; } = new HashSet<Meal>();
    }
}
