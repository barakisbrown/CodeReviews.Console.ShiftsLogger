// <copyright file="Helper.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>
namespace ShiftLogger.Barakisbrown.UI.UserInput;

using ShiftLogger.Barakisbrown.UI.DTO;
using ShiftLogger.Barakisbrown.UI.Models;
using Spectre.Console;

/// <summary>
/// A static class that contain helper static functions.
/// </summary>
public static class Helper
{
    /// <summary>
    /// Shows a message to the user.
    /// </summary>
    /// <param name="msg"> message being displayed to the screen.</param>
    public static void ShowMsg(string msg)
    {
        AnsiConsole.MarkupLine(msg);
    }

    /// <summary>
    /// Displays a Nothing found here message.
    /// </summary>
    public static void ShowNotFound()
    {
        AnsiConsole.MarkupLineInterpolated($"[RED]Nothing Found Here![/]");
    }

    /// <summary>
    /// Displays an Ansiconsole exception message.
    /// </summary>
    /// <param name="xcpt"> exception message being displayed.</param>
    public static void ShowException(Exception xcpt)
    {
        AnsiConsole.WriteException(xcpt);
    }

    /// <summary>
    /// Displays an employee full name to the screen.
    /// </summary>
    /// <param name="emp"> employee name being displayed.</param>
    public static void DisplayFullName(Employee emp)
    {
        var fullName = emp.FirstName + " " + emp.LastName;
        Console.Out.WriteLineAsync(fullName);
    }

    /// <summary>
    /// Display the error to the screen.
    /// </summary>
    /// <param name="msg"> Message displayed to the screen.</param>
    public static void ShowError(string msg)
    {
        AnsiConsole.MarkupLineInterpolated($"[bold red]{msg}[/]");
    }

    /// <summary>
    /// Display a menu and its choices.
    /// </summary>
    /// <param name="name"> the text being displayed for the chioces.</param>
    /// <param name="choices"> An array of numbers to display which choice to choose from.</param>
    /// <returns> TextPrompt containing the prompt being showed to the user. </returns>
    public static TextPrompt<int> ShowMenuChoices(string name, int[] choices)
    {
        return new TextPrompt<int>(name)
                .AddChoices(choices);
    }

    /// <summary>
    /// Display a confirmation message (yes/no).
    /// </summary>
    /// <param name="msg"> the confirmation message shown.</param>
    /// <returns> true or false depening if the user selected yes or no.</returns>
    public static async Task<bool> Confirmation(string msg)
    {
        var confirm = await AnsiConsole.ConfirmAsync(msg);
        return confirm;
    }

    /// <summary>
    /// Let the user select an employee from the available list.
    /// </summary>
    /// <param name="users"> List of available users to choose from.</param>
    /// <returns>EmployeeDTO that the user selects or null if no users are present in the system.</returns>
    public static async Task<EmployeeDTO?> GetUserInfo(List<EmployeeDTO?> users)
    {
        try
        {
            const string title = "SELECT EMPLOYEE FROM LIST";
            var displayUsers = users.ToList();
            if (displayUsers.Count == users.Count)
            {
                displayUsers.Add(new EmployeeDTO { Id = -1, FirstName = "EXIT", LastName = "SELECTION" });
            }

            if (!displayUsers.Exists(x => x.Id == -1))
            {
                displayUsers.Add(new EmployeeDTO { Id = -1, FirstName = "EXIT", LastName = "SELECTION" });
            }

            var choices = new SelectionPrompt<EmployeeDTO>()
                .Title(title)
                .UseConverter(s => $"[bold]{s.FullName}[/]")
                .AddChoices<EmployeeDTO>(displayUsers);
            var prompt = await AnsiConsole.PromptAsync(choices);
            return prompt;
        }
        catch (NullReferenceException ext)
        {
            Helper.ShowError("An error occured accessing the system.");
            return null;
        }
    }
}
