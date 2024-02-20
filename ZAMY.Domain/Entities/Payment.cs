namespace ZAMY.Domain.Entities
{
    public class Payment : _BaseEntity
    {
        public string PaymentMethod { get; set; }
        public decimal TotalValue { get; set; }
        public int TransactionId { get; set; }
        public bool status { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentDetailes { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
