using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Comment { get; set; }
        public double KitchenRating { get; set; }
        public double DeliveryServiceRating { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
    }
}
