// <copyright file="IShiftRepo.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>

namespace ShiftLogger.Barakisbrown.UI.Interfaces;

using ShiftLogger.Barakisbrown.UI.Models;

/// <summary>
/// Interface for the Shift Repository.
/// </summary>
public interface IShiftRepo
{
    /// <summary>
    /// Return all shifts or returns null.
    /// </summary>
    /// <returns> List of Shifts or Null.</returns>
    Task<List<Shifts?>> GetAllShiftsAsync();
}
