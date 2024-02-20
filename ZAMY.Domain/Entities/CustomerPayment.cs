using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Entities
{
    public class CustomerPayment
    {
        public int Id {get; set; }
        public int CreditCardNumer { get; set; }
        public int CredEXPMonth { get; set; }
        public int CredEXPYear { get; set; }
        public int CredSecurityNumber { get; set; }
        public bool IsDefault { get; set; }
        public int CustomerId { get; set; }
        public int PaymentMethodId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}
