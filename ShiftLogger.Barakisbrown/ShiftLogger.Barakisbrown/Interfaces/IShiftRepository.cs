namespace ShiftLogger.Barakisbrown.Interfaces;

using ShiftLogger.Barakisbrown.Models;

public interface IShiftRepository
{
    Task<List<Shifts ?>> GetAllAsync(int employeeID);
    Task<Shifts> CreateShift(Shifts shifts);
    Task<Shifts ?> UpdateShift(Shifts updatedShift);
    Task<Shifts?> DeleteShift(int shiftID, int employeeID);
}
