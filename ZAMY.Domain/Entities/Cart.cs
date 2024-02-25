using System.ComponentModel.DataAnnotations;

namespace ZAMY.Domain.Entities
{
    public class Cart : _BaseEntity
    {
        public DateTime CreationDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<CartItem?> CartItems { get; set; } = new HashSet<CartItem?>();
    }
}
