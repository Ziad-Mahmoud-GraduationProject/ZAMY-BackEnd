using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Entities
{
    public class Offer
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DiscountId { get; set; }

    }
}
