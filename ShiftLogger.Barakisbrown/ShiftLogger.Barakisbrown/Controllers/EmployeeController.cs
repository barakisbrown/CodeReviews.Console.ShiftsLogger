using Microsoft.AspNetCore.Mvc;
using ShiftLogger.Barakisbrown.Models;
using ShiftLogger.Barakisbrown.Services;

namespace ShiftLogger.Barakisbrown.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeService.Get();
        }

        [HttpGet("{EmployeeId}")]
        public async Task<ActionResult<Employee>> GetEmployee(int EmployeeId)
        {
            return await _employeeService.GetById(EmployeeId);
        }
    }
}
