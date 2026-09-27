// <copyright file="CreatedDTO.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>

namespace ShiftLogger.Barakisbrown.DTO;

/// <summary>
/// Dto for Shift Creation.
/// </summary>
public class CreatedDTO
{
    /// <summary>
    /// Gets or Sets BeginShift.
    /// </summary>
    public DateTime BeginShift { get; set; }

    /// <summary>
    /// Gets or Sets endShifts.
    /// </summary>
    public DateTime EndShift { get; set; }
}
