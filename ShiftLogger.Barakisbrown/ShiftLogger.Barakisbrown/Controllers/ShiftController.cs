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
        private readonly IShiftRepository _shiftRepo;

        public ShiftController(IShiftRepository repo)
        {
            _shiftRepo = repo;
        }

        // Get an Employee Shifts
        // Get: api/shift/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllEmployeeShifts([FromRoute] int id)
        {
            var shifts = await _shiftRepo.GetAllEmployeeShifts(id);
            if (shifts == null) return NotFound();
            return Ok(shifts);
        }

        // Get a shift based on the shift ID
        // Get: api/shift/shifts/{shiftID}
        [HttpGet("shifts/{shiftID}")]
        public async Task<IActionResult> GetAShift([FromRoute] int shiftID)
        {
            var shift = await _shiftRepo.GetShiftByIdAsync(shiftID);
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
