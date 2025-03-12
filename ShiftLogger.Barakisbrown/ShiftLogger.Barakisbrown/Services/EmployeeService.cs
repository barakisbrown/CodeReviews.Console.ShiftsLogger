using ShiftLogger.Barakisbrown.DataLayer;
using ShiftLogger.Barakisbrown.Models;

namespace ShiftLogger.Barakisbrown.Services;

internal class EmployeeService(ShiftContext shiftContext) : IEmployeeService
{
    private readonly ShiftContext _shiftContext = shiftContext;

    public bool AddEmployee()
    {
        throw new NotImplementedException();
    }

    public List<Employee> GetAllEmployees()
    {
        throw new NotImplementedException();
    }

    public List<Shifts> GetAllShifts(int Id)
    {
        throw new NotImplementedException();
    }

    public bool RemoveEmployee()
    {
        throw new NotImplementedException();
    }

    public bool UpdateEmployee()
    {
        throw new NotImplementedException();
    }
}
