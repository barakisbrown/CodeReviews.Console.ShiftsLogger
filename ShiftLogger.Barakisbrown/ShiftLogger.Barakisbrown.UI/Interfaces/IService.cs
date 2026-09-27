// <copyright file="IService.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>

namespace ShiftLogger.Barakisbrown.UI.Interfaces;

/// <summary>
/// Service Interface.
/// </summary>
public interface IService
{
    /// <summary>
    /// Displays a title to the screen.
    /// </summary>
    /// <param name="sectionName">Title Name.</param>
    /// <param name="appVersion"> if null then nothing, else display app version.</param>
    static abstract void Title(string sectionName, string? appVersion);
}
