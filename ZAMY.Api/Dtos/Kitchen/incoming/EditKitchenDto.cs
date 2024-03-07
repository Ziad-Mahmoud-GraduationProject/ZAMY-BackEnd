using ZAMY.Domain.Enums;

namespace ZAMY.Api.Dtos.Kitchen.incoming
{
    public class EditKitchenDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int OwnerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public DateTime BirthOfDate { get; set; }
        public Gender Gender { get; set; }
        public int LandLineNumber { get; set; } 
        public DateTime UpdateOn { get; set; }=DateTime.Now;
        public string UpdatedById { get; set; }
    }
}
