using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ShiftLogger.Barakisbrown.DataLayer;
using ShiftLogger.Barakisbrown.Interfaces;
using ShiftLogger.Barakisbrown.Models;

namespace ShiftLogger.Barakisbrown.Services;

internal class EmployeeService(ShiftContext shiftContext) : IEmployeeRepository
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
        var result = await _shiftContext.Employees.ToListAsync();
        if (result == null)
        {
            return (List<Employee>)Results.NotFound();
        }
        return (List<Employee>)Results.Ok(result);

    }

    public async Task<Employee> GetById(int id)
    {
        var Emp = await _shiftContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        if (Emp == null) return (Employee)Results.NotFound();
        return (Employee)Results.Ok(Emp);
    }

    public async Task Update(Employee updatedEmployee)
    {
        Employee savedEmp = await _shiftContext.Employees.FirstOrDefaultAsync(x => x.Id == updatedEmployee.Id);        
        _shiftContext.Entry(savedEmp).CurrentValues.SetValues(updatedEmployee);
        await _shiftContext.SaveChangesAsync();
        

    }
}
