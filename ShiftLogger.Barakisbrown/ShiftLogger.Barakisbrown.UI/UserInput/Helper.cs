using ShiftLogger.Barakisbrown.UI.Models;
using Spectre.Console;

namespace ShiftLogger.Barakisbrown.UI.UserInput;

public static class Helper
{
    public static void ShowMsg(string msg)
    {
        AnsiConsole.MarkupLine(msg);
    }

    public static void ShowNotFound()
    {
        AnsiConsole.MarkupLineInterpolated($"[RED]Nothing Found Here![/]");
    }

    public static void ShowException(Exception xcpt)
    {
        AnsiConsole.WriteException(xcpt);
    }

    public static void DisplayFullName(Employee emp)
    {
        var fullName = emp.FirstName + " " + emp.LastName;
        AnsiConsole.WriteLine(fullName);
    }
}
