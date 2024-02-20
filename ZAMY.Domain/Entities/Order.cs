using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string PaymentMethod { get; set; }
        public decimal OrderDiscount { get; set; }
        public bool Status { get; set; }
        public DateTime OrderDate { get; set; }
        public string Notes { get; set; }
        public int CustomerId { get; set; }
        public int CartId { get; set; }
        public int DeliveryAddressId { get; set; }
        public int DiscountId { get; set; }
        public virtual Discount? Discount { get; set; }
         public virtual CustomerAddress CustomerAddress { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
    }
}
