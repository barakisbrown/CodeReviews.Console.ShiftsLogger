namespace ShiftLogger.Barakisbrown.Repository;

using Microsoft.EntityFrameworkCore;
using ShiftLogger.Barakisbrown.DataLayer;
using ShiftLogger.Barakisbrown.Interfaces;
using ShiftLogger.Barakisbrown.Models;

public class EmployeeRespository(ShiftContext context) : IEmployeeRepository
{
    private readonly ShiftContext _context = context;

    public async Task<Employee> AddEmployeeAsync(Employee newEmployee)
    {
        await _context.Employees.AddAsync(newEmployee);
        await _context.SaveChangesAsync();
        return newEmployee;
    }

    public async Task<Employee?> Delete(int id)
    {
        var emp = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        if (emp == null) return null;
        _context.Remove(emp);
        await _context.SaveChangesAsync();
        return emp;

    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetByIDAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<Employee?> Update(int id,Employee updatedEmployee)
    {
        var emp = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

        if (emp == null) return null;

        emp.FirstName = updatedEmployee.FirstName;
        emp.LastName = updatedEmployee.LastName;
        emp.shifts = updatedEmployee.shifts;

        await _context.SaveChangesAsync();
        return emp;
    }
}
