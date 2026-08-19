using Microsoft.AspNetCore.Mvc;
using ShiftLogger.Barakisbrown.Interfaces;

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

        // GET=> api/Employee/{id}
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEmployee(int Id)
        {
            var emp = await _employeeRepo.GetByIDAsync(Id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }
    }
}
