using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.CustomValidation
{
    public class EndDateAfterStartDateAttribute:ValidationAttribute
    {
        private readonly string _startDate;
        public EndDateAfterStartDateAttribute(string startDate)
        {
            _startDate=startDate;
        }
        protected override ValidationResult? IsValid(object value,ValidationContext validationContext)
        {
            try
            {
                
                var property = validationContext.ObjectType.GetProperty(_startDate);

                var startDate = (DateTime)property.GetValue(validationContext.ObjectInstance);

                var endDate = (DateTime)value;

                if (endDate >= startDate)
                    return new ValidationResult($"End Date must be after the {_startDate}");

                return ValidationResult.Success;
            }
            catch
            {
               return new ValidationResult("Wrong!");
            }
            
        }
    }
}
