using ShiftLogger.Barakisbrown.Models;

namespace ShiftLogger.Barakisbrown.Services;

public interface IShiftService
{
    Shifts CreateShift();
    Shifts ViewShift(int EmployeeId);
    Shifts EditShift(int EmployeeId);
    bool DeleteShift(int ShiftId,int EmployeeID);
    bool DeleteAllShifts(int EmployeeID);
}
