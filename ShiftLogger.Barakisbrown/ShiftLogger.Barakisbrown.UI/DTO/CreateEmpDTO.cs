// <copyright file="CreateEmpDTO.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>

namespace ShiftLogger.Barakisbrown.UI.DTO;

/// <summary>
/// DTO used for Creating Employees.
/// </summary>
public class CreateEmpDTO
{
    /// <summary>
    /// Gets or Sets Firstname.
    /// </summary>
    required public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or Sets LastName.
    /// </summary>
    required public string LastName { get; set; } = string.Empty;
}
