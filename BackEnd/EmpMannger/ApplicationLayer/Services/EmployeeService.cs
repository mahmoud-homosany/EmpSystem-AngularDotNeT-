using ApplicationLayer.Contract;
using AutoMapper;
using DTOS.EmpDTO;
using DTOS.Shared;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmpReposatiry emprepo;
        private readonly IMapper _mapper;

        public EmployeeService(IEmpReposatiry _emprepo , IMapper mapper)
        {
            emprepo = _emprepo;
            _mapper = mapper;
        }

        public async Task<ResultView<CreateOrUpdateVM>> CreateAsync(CreateOrUpdateVM Entity)
        {
            var result = new ResultView<CreateOrUpdateVM>();

            try
            {
                bool Exist = (await emprepo.GetAllAsync()).Any(p=> p.Id == Entity.Id);

                if (Exist)
                {
                    result.IsSucess = false;
                    result.MSG = "A Employee with this name already exists.";
                    return result;
                }

                var emp = _mapper.Map<Employee>(Entity);

                await emprepo.CreateAsync(emp);
                await emprepo.SaveChangesAsync();

                var ReturnedEntity = _mapper.Map<CreateOrUpdateVM>(emp);

                result.IsSucess = true;
                result.Entity = ReturnedEntity;
                result.MSG = "Employee created successfully.";
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.MSG = $"An error occurred while creating the Employee: {ex.Message}";
            }

            return result;
        }

        public async Task<ResultView<EmpGetAllVM>> DeleteAsync(int Id)
        {
            var result = new ResultView<EmpGetAllVM>();

            try
            {
                if (Id == null || Id == 0)
                {
                    result.IsSucess = false;
                    result.MSG = "The entity to delete cannot be null.";
                    return result;
                }


                var emp = (await emprepo.GetAllAsync()).FirstOrDefault(p => p.Id == Id);
                if (emp == null)
                {
                    result.IsSucess = false;
                    result.MSG = "No Employee found with the provided ID.";
                    return result;
                }

                await emprepo.DeleteAsync(emp);
                await emprepo.SaveChangesAsync();

                var deletedEmpDto = _mapper.Map<EmpGetAllVM>(emp);

                result.IsSucess = true;
                result.Entity = deletedEmpDto;
                result.MSG = "Employee deleted successfully.";
            }
            catch (Exception ex)
            {
                // Handle exceptions and populate the result
                result.IsSucess = false;
                result.MSG = $"An error occurred while deleting the Employee: {ex.Message}";
            }

            return result;
        }



        public async Task<List<EmpGetAllVM>> GetAllAsync()
        {
            try
            {
                var emp = (await emprepo.GetAllAsync()).Select(p => p);



                if (!emp.Any())
                {
                    return new List<EmpGetAllVM>();
                }
                var Sucess = _mapper.Map<List<EmpGetAllVM>>(emp);

                return Sucess;

            }
            catch (Exception ex)
            {
                throw new Exception("No Employee found.");
            }

        }

        public async Task<List<EmpGetAllVM>> GetbySearch(string name)
        {
            
            try
            {

                var employees = (await emprepo.Search(name));
                if(employees == null || !employees.Any())
                {
                    return new List<EmpGetAllVM>();
                }

                var successEntity = _mapper.Map<List<EmpGetAllVM>>(employees);
                return successEntity;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetbySearch: {ex.Message}");
                return new List<EmpGetAllVM>();
            }
            return new List<EmpGetAllVM>();
           
        }

        public async Task<ResultView<EmpGetAllVM>> GetOneAsync(int Id)
        {
            var result = new ResultView<EmpGetAllVM>();

            try
            {
                var Getone = (await emprepo.GetAllAsync()).FirstOrDefault(p => p.Id == Id);

                if (Getone == null)
                {
                    result.IsSucess = false;
                    result.MSG = "No Employee found with the provided ID.";
                    return result;
                }

                var successEntity = _mapper.Map<EmpGetAllVM>(Getone);
                result.IsSucess = true;
                result.Entity = successEntity;
                result.MSG = "Employee retrieved successfully.";
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.MSG = $"An error occurred while retrieving the Employee: {ex.Message}";
            }

            return result;
        }

        public async Task<ResultView<CreateOrUpdateVM>> UpdateAsync(CreateOrUpdateVM Entity)
        {
            var result = new ResultView<CreateOrUpdateVM>();

            try
            {
                if (Entity == null)
                {
                    result.IsSucess = false;
                    result.MSG = "The entity to update cannot be null.";
                    return result;
                }

                bool exists = (await emprepo.GetAllAsync()).Any(p => p.Id == Entity.Id);
                if (!exists)
                {
                    result.IsSucess = false;
                    result.MSG = "No Employee found with the provided ID.";
                    return result;
                }

                var emp = _mapper.Map<Employee>(Entity);

                await emprepo.UpdateAsync(emp);
                await emprepo.SaveChangesAsync();

                var updatedProductDto = _mapper.Map<CreateOrUpdateVM>(emp);

                result.IsSucess = true;
                result.Entity = updatedProductDto;
                result.MSG = "Employee updated successfully.";
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.MSG = $"An error occurred while updating the Employee: {ex.Message}";
            }

            return result;
        }




    }

    
}
