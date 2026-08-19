using Microsoft.EntityFrameworkCore;
using ShiftLogger.Barakisbrown.DataLayer;
using ShiftLogger.Barakisbrown.Interfaces;
using ShiftLogger.Barakisbrown.Models;

namespace ShiftLogger.Barakisbrown.Repository
{
    public class ShiftRepository(ShiftContext context) : IShiftRepository
    {
        private readonly ShiftContext _context = context;
        public async Task<Shifts> CreateShift(Shifts shifts)
        {
            await _context.Shifts.AddAsync(shifts);
            await _context.SaveChangesAsync();
            return shifts;
        }

        public async Task<Shifts?> DeleteShift(int shiftID, int employeeID)
        {
            var shifts = await _context.Shifts.FirstOrDefaultAsync(x => x.Id == shiftID && x.EmployeeID == employeeID);
            if (shifts == null) return null;
            _context.Shifts.Remove(shifts);
            await _context.SaveChangesAsync();
            return shifts;

        }

        public async Task<List<Shifts ?>> GetAllAsync(int employeeID)
        {
            var shifts = await _context.Shifts.Where(s => s.EmployeeID == employeeID).ToListAsync();
            if (shifts == null) return null;
            return shifts;
        }

        public async Task<Shifts?> UpdateShift(Shifts updatedShift)
        {
            var shift = await _context.Shifts.FirstOrDefaultAsync(x => x.Id == updatedShift.Id);
            if (shift == null) return null;
            shift.BeginShift = updatedShift.BeginShift;
            shift.EndShift = updatedShift.EndShift;
            shift.EmployeeID = updatedShift.EmployeeID;
            shift.Employee = updatedShift.Employee;
            await _context.SaveChangesAsync();
            return shift;
        }
    }
}
