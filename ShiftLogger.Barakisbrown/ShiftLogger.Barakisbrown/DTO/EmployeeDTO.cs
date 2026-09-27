// <copyright file="EmployeeDTO.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>
namespace ShiftLogger.Barakisbrown.DTO;

/// <summary>
/// EmployeeDTO.
/// </summary>
public class EmployeeDTO
{
    /// <summary>
    /// Gets or Sets ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or Sets FirstName.
    /// </summary>
    required public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or Sets LastName.
    /// </summary>
    required public string LastName { get; set; } = string.Empty;
}
