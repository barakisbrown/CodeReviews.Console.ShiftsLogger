// <copyright file="EmployeeController.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>
namespace ShiftLogger.Barakisbrown.Controllers;

using Mapster;
using Microsoft.AspNetCore.Mvc;
using ShiftLogger.Barakisbrown.DTO;
using ShiftLogger.Barakisbrown.Interfaces;
using ShiftLogger.Barakisbrown.Models;

/// <summary>
/// Controller for Employee WebApi.
/// </summary>
[Route("api/employee")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository employeeRepo;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmployeeController"/> class.
    /// </summary>
    /// <param name="empRepo">IEmployeeRepository Interface.</param>
    public EmployeeController(IEmployeeRepository empRepo)
    {
        this.employeeRepo = empRepo;
    }

    /// <summary>
    /// Gets All Employees.
    /// </summary>
    /// <returns>IActionResult.</returns>
    // GET: api/Employees
    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var emps = await this.employeeRepo.GetAllAsync();
        return this.Ok(emps);
    }

    /// <summary>
    /// Checks for an Employee by its id.
    /// </summary>
    /// <param name="id">id of the employee that being searched for.</param>
    /// <returns>IActionResult -> Employee.</returns>
    // GET=> api/Employee/{id}
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetEmployee([FromRoute] int id)
    {
        var emp = await this.employeeRepo.GetByIDAsync(id);
        if (emp == null)
        {
            return this.NotFound();
        }

        return this.Ok(emp);
    }

    /// <summary>
    /// Creates an employee.
    /// </summary>
    /// <param name="emp">EmployeeCreatedDTO object.</param>
    /// <returns>An employee that was created.</returns>
    // PUT=>api/Employee
    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateDTO emp)
    {
        Employee e = emp.Adapt<Employee>();
        await this.employeeRepo.AddEmployeeAsync(e);
        return this.CreatedAtAction(nameof(this.GetEmployee), new { Id = e.Id }, e);
    }

    /// <summary>
    /// Delete an Employee.
    /// </summary>
    /// <param name="id">ID of the employee deleted.</param>
    /// <returns>NoContent or NotFound.</returns>
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
    {
        var deletdEmp = await this.employeeRepo.Delete(id);
        if (deletdEmp == null)
        {
            return this.NotFound();
        }

        return this.NoContent();
    }

    /// <summary>
    /// Updates an Employee.
    /// </summary>
    /// <param name="id">ID of the employee updated.</param>
    /// <param name="updatedEmp">EmployeeDTO contain employee to be updated.</param>
    /// <returns>Employee that has been updated.</returns>
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] EmployeeDTO updatedEmp)
    {
        var tempEmp = updatedEmp.Adapt<Employee>();
        tempEmp = await this.employeeRepo.Update(id, tempEmp);
        if (tempEmp == null)
        {
            return this.NotFound();
        }

        return this.Ok(tempEmp);
    }
}
