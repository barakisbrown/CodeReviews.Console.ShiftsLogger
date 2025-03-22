using ShiftLogger.Barakisbrown.Models;

namespace ShiftLogger.Barakisbrown.Services;

public interface IEmployeeService
{
    public List<Shifts> GetAllShifts(int employeeId);
    public List<Employee> GetAllEmployees();
    public bool AddEmployee(string firstName,string lastName);
    public bool RemoveEmployee(int removeId);
    public bool UpdateEmployee(int updateId, string? firstName, string? lastName);
}
