namespace ShiftLogger.Barakisbrown.Repository;

using Microsoft.EntityFrameworkCore;
using ShiftLogger.Barakisbrown.DataLayer;
using ShiftLogger.Barakisbrown.Interfaces;
using ShiftLogger.Barakisbrown.Models;

public class EmployeeRespository : IEmployeeRepository
{
    private readonly ShiftContext _context;

    public EmployeeRespository(ShiftContext context)
    {
        _context = context;
    }

    public async Task<Employee> AddEmployeeAsync(Employee newEmployee)
    {
        await _context.Employees.AddAsync(newEmployee);
        await _context.SaveChangesAsync();
        return newEmployee;
    }

    public async Task<Employee?> Delete(int id)
    {
        var deletedEmp = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        if (deletedEmp == null) return null;
        _context.Employees.Remove(deletedEmp);
        await _context.SaveChangesAsync();
        return deletedEmp;

    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetByIDAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<Employee?> Update(int id, Employee updatedEmployee)
    {
        var emp = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

        if (emp == null) return null;

        emp.FirstName = updatedEmployee.FirstName;
        emp.LastName = updatedEmployee.LastName;
        emp.shifts = updatedEmployee.shifts;

        await _context.SaveChangesAsync();
        return emp;
    }

    public async Task<Employee> OneTimeUse()
    {
        int id = 1;
        List<Shifts> mine = await _context.Shifts.Where(x => x.EmployeeID == id).ToListAsync();
        var emp = await _context.Employees.FindAsync(id);

        foreach(var shift in mine)
        {
            emp.shifts.Add(shift);
        }

        await _context.SaveChangesAsync();
        return emp;

    }
}
