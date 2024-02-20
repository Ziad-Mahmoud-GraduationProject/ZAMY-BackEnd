using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalValue { get; set; }
        public int TransactionId { get; set; }
        public bool status { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentDetailes { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
    }
}
