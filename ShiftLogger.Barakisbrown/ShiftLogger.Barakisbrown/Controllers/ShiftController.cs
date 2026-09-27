// <copyright file="ShiftController.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>
namespace ShiftLogger.Barakisbrown.Controllers;

using Mapster;
using Microsoft.AspNetCore.Mvc;
using ShiftLogger.Barakisbrown.DTO;
using ShiftLogger.Barakisbrown.Interfaces;
using ShiftLogger.Barakisbrown.Models;

/// <summary>
/// Controller actions for a Shift.
/// </summary>
[ApiController]
[Route("api/shift")]
public class ShiftController : ControllerBase
{
    private readonly IEmployeeRepository empRepo;
    private readonly IShiftRepository shiftRepo;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShiftController"/> class.
    /// </summary>
    /// <param name="repo">IShiftRepo Insterface.</param>
    /// <param name="empRepo">IEmployeeRepo Interface.</param>
    public ShiftController(IShiftRepository repo, IEmployeeRepository empRepo)
    {
        this.shiftRepo = repo;
        this.empRepo = empRepo;
    }

    /// <summary>
    /// Creates an Shift.
    /// </summary>
    /// <param name="empID">employeeID that shifts add to.</param>
    /// <param name="shift">Shifts that needs to be added.</param>
    /// <returns>Shifts created.</returns>
    [HttpPost]
    [Route("{empID}")]
    public async Task<IActionResult> CreateShift([FromRoute] int empID, [FromBody] CreatedDTO shift)
    {
        if (!await this.empRepo.Exist(empID))
        {
            return this.BadRequest("Employee does not exist");
        }

        var tempShift = shift.Adapt<Shifts>();
        await this.shiftRepo.CreateShift(empID, tempShift);
        return this.CreatedAtAction(nameof(this.GetAllEmployeeShifts), new { Id = tempShift.Id }, tempShift);
    }

    /// <summary>
    /// Gets all shifts.
    /// </summary>
    /// <returns>Get all shifts that exist or NotFound.</returns>
    // GET: api/shifts
    [HttpGet]
    public async Task<IActionResult> GetAllShits()
    {
        var shifts = await this.shiftRepo.GetAllShiftsAsync();
        if (shifts == null)
        {
            return this.NotFound();
        }

        return this.Ok(shifts);
    }

    /// <summary>
    /// Gets an employee shifts.
    /// </summary>
    /// <param name="id">id of empoyee that shifts need to be searched for.</param>
    /// <returns>the shifts assocated with this id or NotFound.</returns>
    // Get: api/shift/employee/{id}
    [HttpGet("employee/{id}")]
    public async Task<IActionResult> GetAllEmployeeShifts([FromRoute] int id)
    {
        var shifts = await this.shiftRepo.GetAllEmployeeShifts(id);
        if (shifts == null)
        {
            return this.NotFound();
        }

        return this.Ok(shifts);
    }

    /// <summary>
    /// Returns a shift or NotFound.
    /// </summary>
    /// <param name="id">id of the shift.</param>
    /// <returns>NotFound or shift found.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetShiftBytID(int id)
    {
        var shift = await this.shiftRepo.GetByIdAsync(id);
        if (shift == null)
        {
            return this.NotFound();
        }

        return this.Ok(shift);
    }

    /// <summary>
    /// Deletes a shift.
    /// </summary>
    /// <param name="empID">employee id to be deleted.</param>
    /// <param name="shiftID">id of the shift also to make sure we get it all done.</param>
    /// <returns>NotFoundd or NoContent.</returns>
    [HttpDelete]
    [Route("/employess/{empID}/shifts/{shiftID}")]
    public async Task<IActionResult> DeleteShift([FromRoute] int empID, [FromRoute] int shiftID)
    {
        var delShifts = await this.shiftRepo.DeleteShift(shiftID, empID);
        if (delShifts == null)
        {
            return this.NotFound();
        }

        return this.NoContent();
    }

    /// <summary>
    /// Updates an employee shifts.
    /// </summary>
    /// <param name="id">id of shift that needs to be updated.</param>
    /// <param name="updateDTO">Shifts which will be updated.</param>
    /// <returns>NotFound or shifts being updated.</returns>
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateShift([FromRoute] int id, [FromBody] ShiftDTO updateDTO)
    {
        var tempShift = updateDTO.Adapt<Shifts>();
        tempShift = await this.shiftRepo.UpdateShift(id, tempShift);
        if (tempShift == null)
        {
            return this.NotFound();
        }

        return this.Ok(tempShift);
    }
}
