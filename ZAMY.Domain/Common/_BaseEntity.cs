using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Common
{
    public class _BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateOn { get; set; } = DateTime.Now;
        public DateTime UpdateOn { get; set; }
        public DateTime DeleteOn { get; set; }
        public string? CreatedById { get; set; }
        public string? UpdatedById { get; set; }
        public string? DeletedById { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
