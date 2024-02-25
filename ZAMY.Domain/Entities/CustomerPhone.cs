using System.ComponentModel.DataAnnotations;

namespace ZAMY.Domain.Entities
{
    public class CustomerPhone : _BaseEntity
    {
        [Phone]
        public int Phone { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
