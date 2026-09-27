// <copyright file="Shifts.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>

namespace ShiftLogger.Barakisbrown.Models;

/// <summary>
/// POCO class for an Employee
/// </summary>
public class Shifts
{
    /// <summary>
    /// Gets or Sets the ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or Sets the BeginShift.
    /// </summary>
    public DateTime BeginShift { get; set; }

    /// <summary>
    /// Gets or Sets the Endshift.
    /// </summary>
    public DateTime EndShift { get; set; }

    /// <summary>
    /// Gets or Sets the EmployeeID.
    /// </summary>
    public int EmployeeID { get; set; }

    /// <summary>
    /// Gets or Sets Employee.
    /// </summary>
    public Employee Employee { get; set; } = null!;
}