using ShiftLogger.Barakisbrown.UI.DTO;
using ShiftLogger.Barakisbrown.UI.Models;

namespace ShiftLogger.Barakisbrown.UI.Interfaces;

public interface IEmployeeRepo
{
    public Task<List<Employee?>> GetEmployeesAsync();

    public Task<Employee ?> GetEmployeeById(int id);

    public Task<Employee?> CreateEmployee(CreateEmpDTO empDTO);
}
