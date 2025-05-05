using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.EmpDTO
{
    public class CreateOrUpdateVM
    {
        public int Id { get; init; }
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(2)]
        public string Position { get; set; }
    }
}
