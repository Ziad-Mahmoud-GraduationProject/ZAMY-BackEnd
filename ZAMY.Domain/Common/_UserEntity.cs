using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Common
{
    public class _UserEntity : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string? MiddleName { get; set; } = string.Empty;
        public DateTime? BirthOfDate { get; set; }
       // public Gender? Gender { get; set; }
        public string? Image { get; set; } = string.Empty;

        public DateTime CreateOn { get; set; } = DateTime.Now;
        public DateTime? UpdateOn { get; set; }
        public DateTime? DeleteOn { get; set; }
        public string? CreatedById { get; set; }
        public string? UpdatedById { get; set; }
        public string? DeletedById { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
