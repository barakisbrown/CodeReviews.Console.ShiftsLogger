using Microsoft.Extensions.Logging;
using ShiftLogger.Barakisbrown.UI.DTO;
using ShiftLogger.Barakisbrown.UI.Interfaces;
using ShiftLogger.Barakisbrown.UI.UserInput;
using Spectre.Console;

namespace ShiftLogger.Barakisbrown.UI;

public class App : IService
{
    private IEmployeeRepo _empRepo;
    private IShiftRepo _shiftRep;
    private ILogger<App> _logger;

    public App(
        IEmployeeRepo empRepo, IShiftRepo shiftRepo, ILogger<App> logger)
    {
        _empRepo = empRepo;
        _shiftRep = shiftRepo;
        _logger = logger;
    }


    public async Task Run()
    {                
        await DisplayMenu();
        //try
        //{
        //    List<EmployeeDTO ?> emps = await _empRepo.GetAllEmployees();

        //    if (emps == null)
        //    {
        //        Helper.ShowError("Employees where not found in the server. Contact Admin.");
        //    }
        //    ListEmployees(emps);
        //}
        //catch (Exception)
        //{
        //    Helper.ShowError("Server is not responding.  Contact Admin for further assisstance.");
        //}
    }

    private async Task DisplayMenu()
    {
        bool exit = false;
        while (!exit)
        {
            AnsiConsole.Clear();
            Title("Shift Logger Application","1.0.0");
            await Console.Out.WriteLineAsync();
            Helper.ShowMsg("Application Main Menu");
            Helper.ShowMsg("----------------------");
            Helper.ShowMsg("1. Employee Section   ");
            Helper.ShowMsg("2. Shifts Section     ");
            Helper.ShowMsg("3. Exit Shift Logger  ");
            Helper.ShowMsg("----------------------");
            var choices = await AnsiConsole.PromptAsync(Helper.ShowMenuChoices("Select Option", [1, 2, 3]));
            switch (choices)
            {
                case 1:
                    EmployeeService service = new EmployeeService(_empRepo, _shiftRep, _logger);
                    await service.Run();
                    break;
                case 2:
                    Helper.ShowMsg($"[yellow]Not Implemented yet.[/]");
                    Thread.Sleep(3000);
                    break;
                case 3:
                    exit = true;
                    break;
            }
        }

    }
    public static void Title(string sectionName, string? appVersion)
    {
        AnsiConsole.Write(

              new FigletText(sectionName)
              .Centered()
              .Color(Color.Blue));
        if (appVersion is not null)
        {
            AnsiConsole.Write(
            new FigletText(appVersion)
            .Centered()
            .Color(Color.Blue)
            );
        }
    }
}