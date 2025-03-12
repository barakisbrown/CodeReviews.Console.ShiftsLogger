using ShiftLogger.Barakisbrown.Models;

namespace ShiftLogger.Barakisbrown.Services;

public interface IEmployeeService
{
    public List<Shifts> GetAllShifts(int Id);
    public List<Employee> GetAllEmployees();
    public bool AddEmployee();
    public bool RemoveEmployee();
    public bool UpdateEmployee();
}
