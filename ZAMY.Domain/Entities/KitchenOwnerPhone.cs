using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Entities
{
    public class KitchenOwnerPhone
    {
        public int Phone { get; set; }
        public int KitchenId { get; set; }
        public virtual Kitchen Kitchen { get; set; }
    }
}
