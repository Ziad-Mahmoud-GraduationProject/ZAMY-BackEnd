using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Entities
{
    public  class Kitchen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int OwnerId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public int NationalId { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public DateOnly BirthOfDate { get; set; }
        public string Gender { get; set; }
        public int LandLineNumber { get; set; }
        public virtual ICollection<KitchenPhoto> KitchenPhotos { get; set; } = new HashSet<KitchenPhoto>();
        public virtual ICollection<KitchenOwnerPhone> KitchenOwnerPhones { get; set; } = new HashSet<KitchenOwnerPhone>();
    }
}
