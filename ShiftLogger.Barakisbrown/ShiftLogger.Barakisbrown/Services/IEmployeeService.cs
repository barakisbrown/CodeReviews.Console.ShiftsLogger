using ShiftLogger.Barakisbrown.Models;

namespace ShiftLogger.Barakisbrown.Services;

public interface IEmployeeService
{   
    // RETRY INFO BELOW
    Task<List<Employee>> Get();

    Task<Employee> GetById(int id);

    Task<Employee> AddEmployee(Employee newEmployee);

    Task Update(Employee updatedEmployee);

    Task Delete(int id);
}
