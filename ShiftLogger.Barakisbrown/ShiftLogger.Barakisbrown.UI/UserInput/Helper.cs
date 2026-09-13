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
        Console.Out.WriteLineAsync(fullName);
    }

    public static void ShowError(string msg)
    {
        AnsiConsole.MarkupLineInterpolated($"[bold red]{msg}[/]"); 
    }

    public static TextPrompt<int> ShowMenuChoices(string name,int[] choices)
    {
        return new TextPrompt<int>(name)
                .AddChoices(choices);
    }

    public async static Task<bool> Confirmation(string msg)
    {
        var confirm = await AnsiConsole.ConfirmAsync(msg);
        return confirm;
    }
}
