using Microsoft.EntityFrameworkCore;
using ShiftLogger.Barakisbrown.DataLayer;
using ShiftLogger.Barakisbrown.Models;

namespace ShiftLogger.Barakisbrown.Services;

internal class EmployeeService(ShiftContext shiftContext) : IEmployeeService
{
    private readonly ShiftContext _shiftContext = shiftContext;

    // RETRY BELOW
    public async Task<Employee> AddEmployee(Employee newEmployee)
    {
        _shiftContext.Add(newEmployee);
        await _shiftContext.SaveChangesAsync();

        return newEmployee;
    }

    public async Task Delete(int id)
    {
        var employeeToDelete = await _shiftContext.Employees.FindAsync(id); 
        _shiftContext.Employees.Remove(employeeToDelete);
        await _shiftContext.SaveChangesAsync();
    }

    public async Task<List<Employee>> Get()
    {
        return await _shiftContext.Employees.ToListAsync();
    }

    public async Task<Employee> GetById(int id)
    {
        var Emp = await _shiftContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        return Emp;
    }

    public async Task Update(Employee updatedEmployee)
    {
        _shiftContext.Entry(updatedEmployee).State = EntityState.Modified;
        await _shiftContext.SaveChangesAsync();
    }
}
