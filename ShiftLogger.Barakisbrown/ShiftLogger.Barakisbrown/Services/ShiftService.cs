using ShiftLogger.Barakisbrown.DataLayer;
using ShiftLogger.Barakisbrown.Models;

namespace ShiftLogger.Barakisbrown.Services;

internal class ShiftService(ShiftContext context) : IShiftService
{
    private readonly ShiftContext _context = context;

    public Shifts CreateShift()
    {
        throw new NotImplementedException();
    }

    public bool DeleteAllShifts(int EmployeeID)
    {
        throw new NotImplementedException();
    }

    public bool DeleteShift(int ShiftId, int EmployeeID)
    {
        throw new NotImplementedException();
    }

    public Shifts EditShift(int EmployeeId)
    {
        throw new NotImplementedException();
    }

    public Shifts ViewShift(int EmployeeId)
    {
        throw new NotImplementedException();
    }
}
