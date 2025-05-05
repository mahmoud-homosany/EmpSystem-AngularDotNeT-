using ApplicationLayer.Services;
using DTOS.EmpDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService emserv;

        public EmployeeController( IEmployeeService _emserv)
        {
            emserv = _emserv;
        }



        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id>0)
            {
            var emp = await emserv.GetOneAsync(id);
            return Ok(emp);
                
            }
            return BadRequest("not Found");
            
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           
            var emps= await emserv.GetAllAsync();

            return Ok(emps);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateOrUpdateVM employee)
        {
            if (ModelState.IsValid)
            {
                
                if(employee != null)
                {
                var created =  await emserv.CreateAsync(employee); 

                 return Ok(created);


                }

         
            }

            return BadRequest("Not Valid");

        }


        [HttpPut("update")]
        public async Task<IActionResult> Update(CreateOrUpdateVM employee)
        {
            if (ModelState.IsValid)
            {

                if (employee != null)
                {
                    var created = await emserv.UpdateAsync(employee);

                    return Ok(created);


                }


            }

            return BadRequest("Not Valid");

        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var emp = await emserv.DeleteAsync(id);
                return Ok(emp);

            }
            return BadRequest("Can't Delete ");
        }


        [HttpGet("by-name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Name is required");
            
            
                var emp = await emserv.GetbySearch(name);

                return Ok(emp);
        }


    }
}
