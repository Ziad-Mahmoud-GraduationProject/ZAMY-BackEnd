using System.ComponentModel.DataAnnotations;

namespace ZAMY.Domain.Entities
{
    public class CustomerPayment : _BaseEntity
    {
        [CreditCard( ErrorMessage="Enter Correct Number")]
        public int CreditCardNumer { get; set; }
        public int CredEXPMonth { get; set; }
        public int CredEXPYear { get; set; }
        public int CredSecurityNumber { get; set; }
        public bool IsDefault { get; set; }=false;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
