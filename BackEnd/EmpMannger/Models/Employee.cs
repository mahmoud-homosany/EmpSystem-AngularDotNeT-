using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee:BaseEntity<int>
    {
        [MinLength(2)]
        [MaxLength(20)]
        public required string FirstName { get; set; }
        [MinLength(2)]
        [MaxLength(20)]
        public  required string LastName { get; set; }
     
        public required string Email { get; set; }
        [MinLength(2)]
        public string Position { get; set; }
    }
}
