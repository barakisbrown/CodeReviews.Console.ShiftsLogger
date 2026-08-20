using Mapster;
using Microsoft.AspNetCore.Mvc;
using ShiftLogger.Barakisbrown.DTO;
using ShiftLogger.Barakisbrown.Interfaces;
using ShiftLogger.Barakisbrown.Models;
using System.Reflection.Metadata.Ecma335;

namespace ShiftLogger.Barakisbrown.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeController(IEmployeeRepository empRepo)
        {
            _employeeRepo = empRepo;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var emps = await _employeeRepo.GetAllAsync();
            return Ok(emps);
        }

        [HttpGet]
        [Route("onetimeuse")]
        public async Task<IActionResult> OneTimeUse()
        {
            await _employeeRepo.OneTimeUse();
            return Ok();
        }

        // GET=> api/Employee/{id}
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEmployee(int Id)
        {
            var emp = await _employeeRepo.GetByIDAsync(Id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }

        // PUT=>api/Employee
        // Creating an Employee
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDTO emp)        
        {
            Employee e = emp.Adapt<Employee>();
            await _employeeRepo.AddEmployeeAsync(e);
            return CreatedAtAction(nameof(GetEmployee), new { Id = e.Id }, e);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var deletdEmp = await _employeeRepo.Delete(id);
            if (deletdEmp == null) return NotFound();
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] EmployeeDTO updatedEmp)
        {
            var tempEmp = updatedEmp.Adapt<Employee>();
            tempEmp = await _employeeRepo.Update(id, tempEmp);
            if (tempEmp == null) return NotFound();
            return Ok(tempEmp);

        }

    }
}
