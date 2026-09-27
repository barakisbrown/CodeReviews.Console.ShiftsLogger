// <copyright file="IEmployeeRepository.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>
namespace ShiftLogger.Barakisbrown.Interfaces;

using ShiftLogger.Barakisbrown.Models;

/// <summary>
/// Interface for Employee Repository.
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// Get All Employeee
    /// </summary>
    /// <returns>List of Employees.</returns>
    Task<List<Employee>> GetAllAsync();

    /// <summary>
    /// Get Employee by ID.
    /// </summary>
    /// <param name="id">id of the employee fetching.</param>
    /// <returns>The employee or null.</returns>
    Task<Employee?> GetByIDAsync(int id);

    /// <summary>
    /// Creates an Employee.
    /// </summary>
    /// <param name="newEmployee">Employee Created.</param>
    /// <returns> Employee who was created.</returns>
    Task<Employee> AddEmployeeAsync(Employee newEmployee);

    /// <summary>
    /// Updats and Employee.
    /// </summary>
    /// <param name="id">Id of the employee who needs updated.</param>
    /// <param name="updatedEmployee">Employee who is need updated.</param>
    /// <returns>Null or Updated Employee.</returns>
    Task<Employee?> Update(int id, Employee updatedEmployee);

    /// <summary>
    /// Deletes an employee.
    /// </summary>
    /// <param name="id">Id of Employee being deleted.</param>
    /// <returns>Employee deleted or Null.</returns>
    Task<Employee?> Delete(int id);
    /// <summary>
    /// Check if Employee Exists.
    /// </summary>
    /// <param name="id">id to see if it exists.</param>
    /// <returns>true or false.</returns>
    Task<bool> Exist(int id);
}
