using Mapster;
using Microsoft.EntityFrameworkCore;
using ShiftLogger.Barakisbrown.DataLayer;
using ShiftLogger.Barakisbrown.Interfaces;
using ShiftLogger.Barakisbrown.Models;

namespace ShiftLogger.Barakisbrown.Repository
{
    public class ShiftRepository(ShiftContext context) : IShiftRepository
    {
        private readonly ShiftContext _context = context;
        public async Task<Shifts> CreateShift(int empID,Shifts shifts)
        {
            // FK CAN NOT BE 0 WHEN ADDING
            shifts.EmployeeID = empID;
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

        public async Task<List<Shifts?>> GetAllEmployeeShifts(int employeeID)
        {
            var empShifts = await _context.Shifts.AnyAsync(s => s.EmployeeID == employeeID);
            if (!empShifts) return null;
            var shifts = await _context.Shifts.Where(s => s.EmployeeID == employeeID).ToListAsync();
            return shifts;
        }

        public async Task<List<Shifts>> GetAllShiftsAsync()
        {
            return await _context.Shifts.ToListAsync();
        }

        public async Task<Shifts?> GetByIdAsync(int id)
        {
            return await _context.Shifts.FindAsync(id);
        }

        public async Task<Shifts?> GetShiftByIdAsync(int shiftID)
        {
            var shift = await _context.Shifts.FirstOrDefaultAsync(x => x.Id == shiftID);
            if (shift == null) return null;
            return shift;
        }
        
        public async Task<Shifts?> UpdateShift(int id,Shifts updatedShift)
        {
            var shift = await _context.Shifts.FirstOrDefaultAsync(x => x.Id == id);
            if (shift == null) return null;
            shift.BeginShift = updatedShift.BeginShift;
            shift.EndShift = updatedShift.EndShift;
            await _context.SaveChangesAsync();
            return shift;
        }
    }
}
