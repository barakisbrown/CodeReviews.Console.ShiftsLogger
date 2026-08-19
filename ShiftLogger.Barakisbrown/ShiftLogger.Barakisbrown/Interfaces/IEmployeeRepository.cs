namespace ShiftLogger.Barakisbrown.Interfaces;

using ShiftLogger.Barakisbrown.Models;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllAsync();

    Task<Employee?> GetByIDAsync(int id);

    Task<Employee> AddEmployeeAsync(Employee newEmployee);

    Task<Employee ?> Update(Employee updatedEmployee);
    Task<Employee?> Delete(int id);
}
