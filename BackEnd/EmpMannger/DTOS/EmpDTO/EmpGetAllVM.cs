﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.EmpDTO
{
    public class EmpGetAllVM
    {
        public int Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string Email { get; set; }
      
        public string Position { get; set; }
    }
}
