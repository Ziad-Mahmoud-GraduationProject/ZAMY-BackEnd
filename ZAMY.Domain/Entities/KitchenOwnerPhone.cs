﻿using System.ComponentModel.DataAnnotations;

namespace ZAMY.Domain.Entities
{
    public class KitchenOwnerPhone : _BaseEntity
    {
        [Phone]
        public string Phone { get; set; }
        public int KitchenId { get; set; }
        public Kitchen Kitchen { get; set; }
    }
}
