using ZAMY.Domain.CustomValidation;

namespace ZAMY.Domain.Entities
{
    public class Offer : _BaseEntity
    {
        public DateTime StartDate { get; set; }
        [EndDateAfterStartDate(nameof(StartDate))]
        public DateTime? EndDate { get; set; }
        public Discount? Discount { get; set; } 
        public ICollection<Meal> Meals { get; set; } = new HashSet<Meal>();
    }
}
