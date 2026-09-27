// <copyright file="Shifts.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>

namespace ShiftLogger.Barakisbrown.UI.Models;

/// <summary>
/// POCO class for the Shifts Object.
/// </summary>
public class Shifts
{
    /// <summary>
    /// Gets or Sets ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or Sets BeginShift.
    /// </summary>
    public DateTime BeginShift { get; set; }

    /// <summary>
    /// Gets or Sets EndShift.
    /// </summary>
    public DateTime EndShift { get; set; }

    /// <summary>
    /// Gets or Sets EmployeeID which is a foreign key.
    /// </summary>
    public int EmployeeID { get; set; }

    /// <summary>
    /// Gets or Sets Employee class.
    /// </summary>
    public Employee Employee { get; set; } = null!;
}
