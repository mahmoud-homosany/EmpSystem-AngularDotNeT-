using ApplicationLayer.Contract;
using EContext;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer
{
    public class EmpRepo : GenericRepo<Employee,int>,IEmpReposatiry
    {
        private readonly TContext _context;

        public EmpRepo(TContext context):base(context)
        {
            _context=context;
        }

        public async Task<List<Employee>> Search(string name)
        {
            return await _context.Employss
        .Where(e => e.FirstName.ToLower().Contains(name.ToLower()))
        .ToListAsync();
        } 





    }
}
