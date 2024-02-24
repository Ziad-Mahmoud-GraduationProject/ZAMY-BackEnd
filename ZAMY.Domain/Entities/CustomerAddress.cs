﻿namespace ZAMY.Domain.Entities
{
    public class CustomerAddress : _BaseEntity
    {
        public string Governorate { get; set; } 
        public string City { get; set; }
        public string Region { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Order?> Orders { get; set; } = new HashSet<Order?>();
    }
}
