// <copyright file="EmployeeCreateDTO.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>
namespace ShiftLogger.Barakisbrown.DTO;

/// <summary>
/// EmployeeCreateDTO class.
/// </summary>
public class EmployeeCreateDTO
{
    /// <summary>
    /// gets or sets FirstName.
    /// </summary>
    required public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or Sets LastName.
    /// </summary>
    required public string LastName { get; set; } = string.Empty;
}
