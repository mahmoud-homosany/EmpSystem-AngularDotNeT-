using DTOS.EmpDTO;
using DTOS.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface IEmployeeService
    {
        Task<ResultView<CreateOrUpdateVM>> CreateAsync(CreateOrUpdateVM Entity);
        Task<ResultView<CreateOrUpdateVM>> UpdateAsync(CreateOrUpdateVM Entity);
        Task<List<EmpGetAllVM>> GetAllAsync();
        Task<ResultView<EmpGetAllVM>> GetOneAsync(int Id);
        Task<ResultView<EmpGetAllVM>> DeleteAsync(int Id);
        Task<List<EmpGetAllVM>> GetbySearch(string name);

    }
}
