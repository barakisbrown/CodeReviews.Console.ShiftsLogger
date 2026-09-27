// <copyright file="ShiftDTO.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>

namespace ShiftLogger.Barakisbrown.UI.DTO;

/// <summary>
/// DTO for Shifts.
/// </summary>
public class ShiftDTO
{
    /// <summary>
    /// Gets or Sets ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or Sets BeginShift.
    /// </summary>
    public DateTime BeginShift { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or Sets EndShift.
    /// </summary>
    public DateTime EndShift { get; set; } = DateTime.Now;
}
