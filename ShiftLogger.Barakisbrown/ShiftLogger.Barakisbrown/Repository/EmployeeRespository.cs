// <copyright file="EmployeeRespository.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>
namespace ShiftLogger.Barakisbrown.Repository;

using Microsoft.EntityFrameworkCore;
using ShiftLogger.Barakisbrown.DataLayer;
using ShiftLogger.Barakisbrown.Interfaces;
using ShiftLogger.Barakisbrown.Models;

/// <summary>
/// Initializes a new instance of the <see cref="EmployeeRespository"/> class.
/// </summary>
/// <param name="context">DB CONTEXT.</param>
#pragma warning disable SA1009 // ClosingParenthesisMustBeSpacedCorrectly
public class EmployeeRespository(ShiftContext context) : IEmployeeRepository
{
    private readonly ShiftContext context = context;

    /// <summary>
    /// Creates a new Employee.
    /// </summary>
    /// <param name="newEmployee">Employee to be added.</param>
    /// <returns> Employee created.</returns>
    public async Task<Employee> AddEmployeeAsync(Employee newEmployee)
    {
        await this.context.Employees.AddAsync(newEmployee);
        await this.context.SaveChangesAsync();
        return newEmployee;
    }

    /// <summary>
    /// Delete an employee.
    /// </summary>
    /// <param name="id">id of the employee being deleted.</param>
    /// <returns>Employee Deleted.</returns>
    public async Task<Employee?> Delete(int id)
    {
        var deletedEmp = await this.context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        if (deletedEmp == null)
        {
            return null;
        }

        this.context.Employees.Remove(deletedEmp);
        await this.context.SaveChangesAsync();
        return deletedEmp;
    }

    /// <summary>
    /// Check if Employee exist.
    /// </summary>
    /// <param name="id">id to see if emp exist.</param>
    /// <returns>true or false.</returns>
    public async Task<bool> Exist(int id)
    {
        return await this.context.Employees.AnyAsync(x => x.Id == id);
    }

    /// <summary>
    /// Get all Employees.
    /// </summary>
    /// <returns>List of Employees.</returns>
    public async Task<List<Employee>> GetAllAsync()
    {
        return await this.context.Employees.Include(e => e.Shifts).ToListAsync();
    }

    /// <summary>
    /// Find Employee by ID.
    /// </summary>
    /// <param name="id">id searching for.</param>
    /// <returns>Null or Employee.</returns>
    public async Task<Employee?> GetByIDAsync(int id)
    {
        return await this.context.Employees.Include(e => e.Shifts).FirstOrDefaultAsync(x => x.Id == id);
    }

    /// <summary>
    /// Updated an Employee.
    /// </summary>
    /// <param name="id">id of employee being updated.</param>
    /// <param name="updatedEmployee">Updated Employee info to be updated.</param>
    /// <returns>Employee being updated.</returns>
    public async Task<Employee?> Update(int id, Employee updatedEmployee)
    {
        var emp = await this.context.Employees.FirstOrDefaultAsync(x => x.Id == id);

        if (emp == null)
        {
            return null;
        }

        emp.FirstName = updatedEmployee.FirstName;
        emp.LastName = updatedEmployee.LastName;
        emp.Shifts = updatedEmployee.Shifts;

        await this.context.SaveChangesAsync();
        return emp;
    }
}
