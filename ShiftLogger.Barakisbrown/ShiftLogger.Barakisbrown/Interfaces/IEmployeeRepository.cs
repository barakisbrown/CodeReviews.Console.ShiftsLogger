using ShiftLogger.Barakisbrown.DTO;
using ShiftLogger.Barakisbrown.Models;

namespace ShiftLogger.Barakisbrown.Interfaces;

public interface IEmployeeRepository
{   
    // RETRY INFO BELOW
    Task<List<EmployeeResponse>> GetAsync();

    Task<EmployeeResponse ?> GetByIdAsync(int id);

    Task<EmployeeResponse> AddEmployeeAsync(Employee newEmployee);

    Task<EmployeeResponse ?> UpdateAsync(Employee updatedEmployee);

    Task <Employee ?> DeleteAsync(int id);
}
