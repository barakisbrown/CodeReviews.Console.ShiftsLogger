namespace ShiftLogger.Barakisbrown.Interfaces;

using ShiftLogger.Barakisbrown.Models;

public interface IShiftRepository
{
    Task<List<Shifts ?>> GetAllEmployeeShifts(int employeeID);
    Task<Shifts?> GetShiftByIdAsync(int shiftID);
    Task<Shifts> CreateShift(Shifts shifts);
    Task<Shifts ?> UpdateShift(int shiftID,Shifts updatedShift);
    Task<Shifts?> DeleteShift(int shiftID, int employeeID);
}
