using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Entities
{
    public class CustomerAddress
    {
        public string Governorate { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
