namespace ShiftLogger.Barakisbrown.Interfaces;

using ShiftLogger.Barakisbrown.Models;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllAsync();

    Task<Employee?> GetByIDAsync(int id);

    Task<Employee> AddEmployeeAsync(Employee newEmployee);

    Task<Employee ?> Update(int id,Employee updatedEmployee);
    Task<Employee?> Delete(int id);

    Task<bool> Exist(int id);
}
