// <copyright file="Employee.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>

namespace ShiftLogger.Barakisbrown.UI.Models;

/// <summary>
/// Employee POCO Class.
/// </summary>
public class Employee
{
    /// <summary>
    /// Gets or sets Id field of the DB.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or Sets FirstName.
    /// </summary>
    required public string FirstName { get; set; }

    /// <summary>
    /// Gets or Sets LastName.
    /// </summary>
    required public string LastName { get; set; }

    // Required reference navigation to principle

    /// <summary>
    /// Gets or Sets Shifts.
    /// </summary>
    public ICollection<Shifts> Shifts { get; set; } = new List<Shifts>();
}
