namespace ShiftLogger.Barakisbrown.Interfaces;

using ShiftLogger.Barakisbrown.Models;

public interface IShiftRepository
{
    Task<List<Shifts>> GetAllShiftsAsync();
    Task<List<Shifts ?>> GetAllEmployeeShifts(int employeeID);

    Task<Shifts ?> GetByIdAsync(int id);
    Task<Shifts> CreateShift(int empID,Shifts shifts);
    Task<Shifts ?> UpdateShift(int shiftID,Shifts updatedShift);
    Task<Shifts?> DeleteShift(int shiftID, int employeeID);
}
