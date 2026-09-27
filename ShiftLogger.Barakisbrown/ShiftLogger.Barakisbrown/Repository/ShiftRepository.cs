// <copyright file="ShiftRepository.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>
namespace ShiftLogger.Barakisbrown.Repository;

using Microsoft.EntityFrameworkCore;
using ShiftLogger.Barakisbrown.DataLayer;
using ShiftLogger.Barakisbrown.Interfaces;
using ShiftLogger.Barakisbrown.Models;

/// <summary>
/// Initializes a new instance of the <see cref="ShiftRepository"/> class.
/// </summary>
/// <param name="context">db context that is needed.</param>
#pragma warning disable SA1009 // ClosingParenthesisMustBeSpacedCorrectly
public class ShiftRepository(ShiftContext context) : IShiftRepository
{
    private readonly ShiftContext context = context;

    /// <summary>
    /// Create shift for employee.
    /// </summary>
    /// <param name="empID">id of employee adding shifts.</param>
    /// <param name="shifts">Shifts being added.</param>
    /// <returns>the shifts created.</returns>
    public async Task<Shifts> CreateShift(int empID, Shifts shifts)
    {
        // FK CAN NOT BE 0 WHEN ADDING
        shifts.EmployeeID = empID;
        await this.context.Shifts.AddAsync(shifts);
        await this.context.SaveChangesAsync();
        return shifts;
    }

    /// <summary>
    /// Delete a shift.
    /// </summary>
    /// <param name="shiftID">id of the shift being deleted.</param>
    /// <param name="employeeID">id of the employee that needs it shift deleted.</param>
    /// <returns>Null or shift deleted.</returns>
    public async Task<Shifts?> DeleteShift(int shiftID, int employeeID)
    {
        var shifts = await this.context.Shifts.FirstOrDefaultAsync(x => x.Id == shiftID && x.EmployeeID == employeeID);
        if (shifts == null)
        {
            return null;
        }

        this.context.Shifts.Remove(shifts);
        await this.context.SaveChangesAsync();
        return shifts;
    }

    /// <summary>
    /// Geta all the employee shifts.
    /// </summary>
    /// <param name="employeeID">id of employee shifts.</param>
    /// <returns>Null or list of shifts assigned to employee.</returns>
    public async Task<List<Shifts?>> GetAllEmployeeShifts(int employeeID)
    {
        var empShifts = await this.context.Shifts.AnyAsync(s => s.EmployeeID == employeeID);
        if (!empShifts)
        {
            return null;
        }

        var shifts = await this.context.Shifts.Where(s => s.EmployeeID == employeeID).ToListAsync();
        return shifts;
    }

    /// <summary>
    /// Get all Shifts.
    /// </summary>
    /// <returns>List of all shifts listed.</returns>
    public async Task<List<Shifts>> GetAllShiftsAsync()
    {
        return await this.context.Shifts.ToListAsync();
    }

    /// <summary>
    /// Gets an shift by its id.
    /// </summary>
    /// <param name="id">Id of shift.</param>
    /// <returns>Null or Shifts.</returns>
    public async Task<Shifts?> GetByIdAsync(int id)
    {
        return await this.context.Shifts.FindAsync(id);
    }

    /// <summary>
    /// Get Shifts by ID.
    /// </summary>
    /// <param name="shiftID">id of the shifts being searched for.</param>
    /// <returns>Shifts being found or Null.</returns>
    public async Task<Shifts?> GetShiftByIdAsync(int shiftID)
    {
        var shift = await this.context.Shifts.FirstOrDefaultAsync(x => x.Id == shiftID);
        if (shift == null)
        {
            return null;
        }

        return shift;
    }

    /// <summary>
    /// Updates a employee shift.
    /// </summary>
    /// <param name="id">id of the shift needs updating.</param>
    /// <param name="updatedShift">Shift information that needs to be updated.</param>
    /// <returns>newly updated shift.</returns>
    public async Task<Shifts?> UpdateShift(int id, Shifts updatedShift)
    {
        var shift = await this.context.Shifts.FirstOrDefaultAsync(x => x.Id == id);
        if (shift == null)
        {
            return null;
        }

        shift.BeginShift = updatedShift.BeginShift;
        shift.EndShift = updatedShift.EndShift;
        await this.context.SaveChangesAsync();
        return shift;
    }
}
