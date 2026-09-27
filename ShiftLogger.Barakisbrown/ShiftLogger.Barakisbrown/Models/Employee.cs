// <copyright file="Employee.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>

namespace ShiftLogger.Barakisbrown.Models;

/// <summary>
/// POCO class for an employee.
/// </summary>
public class Employee
{
    /// <summary>
    /// Gets or Sets the ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or Sets the FirstName.
    /// </summary>
    required public string FirstName { get; set; }

    /// <summary>
    /// Gets or Sets the LastName.
    /// </summary>
    required public string LastName { get; set; }

    /// <summary>
    /// Gets or Sets the Shifts.
    /// </summary>
    // Required reference navigation to principle
    public ICollection<Shifts> Shifts { get; set; } = new List<Shifts>();
}
