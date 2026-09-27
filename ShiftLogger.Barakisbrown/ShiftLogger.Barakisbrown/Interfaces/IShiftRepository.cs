// <copyright file="IShiftRepository.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>
namespace ShiftLogger.Barakisbrown.Interfaces;

using ShiftLogger.Barakisbrown.Models;

/// <summary>
/// Interface for the Shift Repository.
/// </summary>
public interface IShiftRepository
{
    /// <summary>
    /// Geta all shifts.
    /// </summary>
    /// <returns>Return list of Shifts.</returns>
    Task<List<Shifts>> GetAllShiftsAsync();

    /// <summary>
    /// Gets all shifts for an employee.
    /// </summary>
    /// <param name="employeeID">id of employee being searched.</param>
    /// <returns>All shifts for that Employee.</returns>
    Task<List<Shifts?>> GetAllEmployeeShifts(int employeeID);

    /// <summary>
    /// Get Shifts by ID.
    /// </summary>
    /// <param name="id">Id of the shifts need found.</param>
    /// <returns>Null or Shifts.</returns>
    Task<Shifts?> GetByIdAsync(int id);

    /// <summary>
    /// Create a shift for an employee.
    /// </summary>
    /// <param name="empID">id of the employee.</param>
    /// <param name="shifts">Shifts need adding.</param>
    /// <returns>Created Shift.</returns>
    Task<Shifts> CreateShift(int empID, Shifts shifts);

    /// <summary>
    /// Updates a Shift.
    /// </summary>
    /// <param name="shiftID">id of the shift being updated.</param>
    /// <param name="updatedShift">Shift that will updated from.</param>
    /// <returns>Shifts that were updated.</returns>
    Task<Shifts?> UpdateShift(int shiftID, Shifts updatedShift);

    /// <summary>
    /// Deletes a Shift.
    /// </summary>
    /// <param name="shiftID">id of the shift being deleted.</param>
    /// <param name="employeeID">id of employee of the shift being deleted.</param>
    /// <returns>Shift that was deleted or null.</returns>
    Task<Shifts?> DeleteShift(int shiftID, int employeeID);
}
