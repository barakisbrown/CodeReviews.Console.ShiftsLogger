// <copyright file="IEmployeeRepo.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>

namespace ShiftLogger.Barakisbrown.UI.Interfaces;

using ShiftLogger.Barakisbrown.UI.DTO;
using ShiftLogger.Barakisbrown.UI.Models;

/// <summary>
/// Interface for the employee repository.
/// </summary>
public interface IEmployeeRepo
{
    /// <summary>
    /// Returns a List of EmployeeDTO or return null if none are found.
    /// </summary>
    /// <returns>List of Employee DTO or null.</returns>
    public Task<List<EmployeeDTO?>> GetAllEmployees();

    /// <summary>
    /// Gets an employee by its ID and returns it or NULL if not found.
    /// </summary>
    /// <param name="id">ID of the employee trying to find.</param>
    /// <returns>An EmployeeDTO with the employee or null.</returns>
    public Task<EmployeeDTO?> GetEmployeeById(int id);

    /// <summary>
    /// Create an employee.
    /// </summary>
    /// <param name="empDTO">Created Employee DTO.</param>
    /// <returns>NULL OR Employee created.</returns>
    public Task<Employee?> CreateEmployee(CreateEmpDTO empDTO);

    /// <summary>
    /// Get and Employee ID.
    /// </summary>
    /// <param name="empDTO"> CreateEmpDTO to find the id.</param>
    /// <returns>int reprensenting id.</returns>
    public Task<int> GetEmployeeID(CreateEmpDTO empDTO);

    /// <summary>
    /// Deletes an Employee from the system.
    /// </summary>
    /// <param name="employee">Employee being deleted.</param>
    /// <returns>Employee that was deleted.</returns>
    public Task<Employee> DeleteEmployee(EmployeeDTO employee);
}
