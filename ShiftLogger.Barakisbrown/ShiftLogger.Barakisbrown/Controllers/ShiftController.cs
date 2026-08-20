using Microsoft.AspNetCore.Mvc;
using ShiftLogger.Barakisbrown.Interfaces;

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
        public async Task<IActionResult> GetAllShifts(int id)
        {
            var shifts = await _shiftRepo.GetAllAsync(id);
            if (shifts == null) return NotFound();
            return Ok(shifts);

        }
    }
}
