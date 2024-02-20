using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Entities
{
    public class KitchenPhoto
    {
        public string URLPhoto { get; set; }
        public int KitchenId { get; set; }
        public virtual Kitchen Kitchen { get; set; }
    }
}
