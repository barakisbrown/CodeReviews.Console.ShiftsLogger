using ShiftLogger.Barakisbrown.UI.DTO;
using ShiftLogger.Barakisbrown.UI.Models;

namespace ShiftLogger.Barakisbrown.UI.Interfaces;

public interface IEmployeeRepo
{
    public Task<List<EmployeeDTO ?>> GetAllEmployees();

    public Task<EmployeeDTO ?> GetEmployeeById(int id);

    public Task<Employee?> CreateEmployee(CreateEmpDTO empDTO);

    public Task<int> GetEmployeeID(CreateEmpDTO empDTO);
}
