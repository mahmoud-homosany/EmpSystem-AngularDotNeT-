using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EContext
{
    public class TContext:DbContext
    {
       public DbSet<Employee>Employss { get; set; }

        public TContext(DbContextOptions<TContext> dbcontext):base(dbcontext)
        {
            
        }


    }
}
