using Microsoft.EntityFrameworkCore;
using ShiftLogger.Barakisbrown.DataLayer;
using ShiftLogger.Barakisbrown.Models;

namespace ShiftLogger.Barakisbrown.Services;

internal class ShiftService(ShiftContext context) : IShiftService
{
    private readonly ShiftContext _context = context;

    public async Task<List<Shifts>> Get(int EmployeeID)
    {
       return await _context.Shifts.Where(s => s.EmployeeID == EmployeeID).ToListAsync();
    }

    public async Task<Shifts> CreateShift(Shifts shifts)
    {
        _context.Shifts.Add(shifts);
        await _context.SaveChangesAsync();
        return shifts;
    }

    public async Task DeleteShift(int ShiftId, int EmployeeID)
    {
        var shift = _context.Shifts.FirstOrDefault(x => x.Id == ShiftId && x.EmployeeID == EmployeeID);
        _context.Shifts.Remove(shift);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Shifts updatedShift)
    {
        _context.Entry(updatedShift).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
