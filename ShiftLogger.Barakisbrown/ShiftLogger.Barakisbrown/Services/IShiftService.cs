using ShiftLogger.Barakisbrown.Models;

namespace ShiftLogger.Barakisbrown.Services;

public interface IShiftService
{
    Task<List<Shifts>> Get(int EmployeeID);

    Task<Shifts> CreateShift(Shifts shifts);
    
    Task Update(Shifts updatedShift);
    
    Task DeleteShift(int ShiftId,int EmployeeID);
}
