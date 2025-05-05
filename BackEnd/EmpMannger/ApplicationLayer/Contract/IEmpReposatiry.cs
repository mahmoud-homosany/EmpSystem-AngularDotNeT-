using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Contract
{
    public interface IEmpReposatiry:IGenericReposatiry<Employee,int>
    {
        public Task<List<Employee>> Search(string name);
    }
}
