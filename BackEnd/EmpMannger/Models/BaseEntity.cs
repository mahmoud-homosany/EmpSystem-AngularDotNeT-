using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BaseEntity<T>
    {
        public T Id { get; init; }
        public DateTime? CreationDate { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; } = "Mahmoud";
    }
}
