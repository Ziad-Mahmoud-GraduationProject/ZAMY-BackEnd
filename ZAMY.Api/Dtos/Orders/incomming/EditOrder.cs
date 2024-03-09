using ZAMY.Domain.Enums;

namespace ZAMY.Api.Dtos.Orders.incomming
{
    public class EditOrder
    {
        public string PaymentMethod { get; set; }
        public Status Status { get; set; }
        public DateTime OrderDate { get; set; }
        public string Notes { get; set; }
        public int CustomerId { get; set; }
        public int KitchenId { get; set; }
    }
}
