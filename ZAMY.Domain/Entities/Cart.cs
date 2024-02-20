using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public virtual ICollection<CartItem?> CartItems { get; set; } = new HashSet<CartItem>();
        public virtual ICollection<Order?> Orders { get; set; } = new HashSet<Order>();
    }
}
