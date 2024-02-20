using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Entities
{
    public class Discount
    {
        public int Id { get; set; }
        public decimal DiscountPrecent { get; set; }
        public virtual ICollection<Order> Orders { get; set; }=new HashSet<Order>();
    }
}
