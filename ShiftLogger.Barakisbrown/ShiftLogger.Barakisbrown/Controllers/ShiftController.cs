using System.Security.Cryptography.X509Certificates;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using ShiftLogger.Barakisbrown.DTO;
using ShiftLogger.Barakisbrown.Interfaces;
using ShiftLogger.Barakisbrown.Models;

namespace ShiftLogger.Barakisbrown.Controllers
{
    [ApiController]
    [Route("api/shift")]
    public class ShiftController : ControllerBase
    {
        private readonly IEmployeeRepository _empRepo;
        private readonly IShiftRepository _shiftRepo;

        public ShiftController(IShiftRepository repo,IEmployeeRepository empRepo)
        {
            _shiftRepo = repo;
            _empRepo = empRepo;
        }

        // CREATE A SHIFT. EMPID can be 0
        [HttpPost()]
        [Route("{empID}")]
        public async Task<IActionResult> CreateShift([FromRoute] int empID,[FromBody] CreatedDTO shift)
        {
            if (!await _empRepo.Exist(empID)) return BadRequest("Employee does not exist");

            var tempShift = shift.Adapt<Shifts>();
            await _shiftRepo.CreateShift(empID,tempShift);
            return CreatedAtAction(nameof(GetAllEmployeeShifts), new {Id = tempShift.Id},tempShift);

        }
        
        // GET ALL SHIFTS
        // GET: api/shifts
        [HttpGet]
        public async Task<IActionResult> GetAllShits()
        {
            var shifts = await _shiftRepo.GetAllShiftsAsync();
            if (shifts == null) return NotFound();
            return Ok(shifts);
        }
        // Get an Employee Shifts
        // Get: api/shift/employee/{id}
        [HttpGet("employee/{id}")]
        public async Task<IActionResult> GetAllEmployeeShifts([FromRoute] int id)
        {
            var shifts = await _shiftRepo.GetAllEmployeeShifts(id);
            if (shifts == null) return NotFound();
            return Ok(shifts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShiftBytID(int id)
        {
            var shift = await _shiftRepo.GetByIdAsync(id);
            if (shift == null) return NotFound();
            return Ok(shift);
        }

        // DELETE A SHIFT
        [HttpDelete]
        [Route("/employess/{empID}/shifts/{shiftID}")]
        public async Task<IActionResult> DeleteShift([FromRoute] int empID,[FromRoute] int shiftID)
        {
            var delShifts = await _shiftRepo.DeleteShift(shiftID,empID);
            if (delShifts == null) return NotFound();
            return NoContent();
        }

        // UPDATE SHIFT
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateShift([FromRoute]int id,[FromBody] ShiftDTO updateDTO)
        {
            var tempShift = updateDTO.Adapt<Shifts>();
            tempShift = await _shiftRepo.UpdateShift(id,tempShift);
            if (tempShift == null) return NotFound();
            return Ok(tempShift);
        }       
    }
}
