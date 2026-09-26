namespace ShiftLogger.Barakisbrown.UI;

using Microsoft.Extensions.Logging;
using ShiftLogger.Barakisbrown.UI.DTO;
using ShiftLogger.Barakisbrown.UI.Interfaces;
using ShiftLogger.Barakisbrown.UI.Models;
using ShiftLogger.Barakisbrown.UI.UserInput;
using Spectre.Console;



public class EmployeeService : IService
{
    private IEmployeeRepo _empRepo;
    private IShiftRepo _shiftRep;
    private ILogger<App> _logger;

    public EmployeeService(
    IEmployeeRepo empRepo, IShiftRepo shiftRepo, ILogger<App> logger)
    {
        _empRepo = empRepo;
        _shiftRep = shiftRepo;
        _logger = logger;
    }

    public async Task Run()
    {
        bool exit = false;
        while (!exit)
        {
            AnsiConsole.Clear();
            Title("Employee Section","1.0.0");
            AnsiConsole.WriteLine();
            Helper.ShowMsg("Employee Section");
            Helper.ShowMsg("-----------------------");
            Helper.ShowMsg("1.Create a user        ");
            Helper.ShowMsg("2.Search for a user    ");
            Helper.ShowMsg("3.Update Employee info ");
            Helper.ShowMsg("4.Delete Employee      ");
            Helper.ShowMsg("5.List All Employees   ");
            Helper.ShowMsg("6.Exit Section         ");
            Helper.ShowMsg("-----------------------");
            var choices = await AnsiConsole.PromptAsync(Helper.ShowMenuChoices("Select Option", [1, 2, 3, 4, 5,6]));
            switch(choices)
            {
                case >= 2  and <= 4:
                    Helper.ShowMsg($"[yellow]Not implemented yet[/]");
                    Thread.Sleep(3000);
                    break;
                case 1:
                    await CreateUser();
                    Thread.Sleep(2000);
                    break;
                case 5:
                    await DisplayAllEmployees();
                    Thread.Sleep(2000);
                    break;
                case 6:
                    exit = true;
                    break;
            }
        }
    }

    private static void ListEmployees(List<EmployeeDTO?> employees)
    {
        if (employees.Count == 0)
            Helper.ShowMsg("There are currently 0 Employees");
        else
        {
            AnsiConsole.Clear();
            var table = new Table();
            table.Title($"{employees.Count} Employees Listed");
            table.AddColumn("First Name");
            table.AddColumn("Last Name");

            foreach (var emp in employees)
            {
                table.AddRow(emp.FirstName, emp.LastName);
            }

            AnsiConsole.Write(table);

            Helper.ShowMsg("Press any key to return");
            Console.ReadKey(intercept: true);
        }
    }

    private async Task CreateUser()
    {
        while (true)
        {
            AnsiConsole.Clear();
            Title("Create Employee Section",null);
            AnsiConsole.WriteLine();
            // FETCH First and Last Name
            var firstName = await AnsiConsole.PromptAsync(
                new TextPrompt<string>("First Name -> "));
            var lastName = await AnsiConsole.PromptAsync(
                new TextPrompt<string>("Last Name -> "));

            // DO THEY EXIST?
            var id = await _empRepo.GetEmployeeID(new CreateEmpDTO { FirstName = firstName, LastName = lastName });
            if (id != -1)
            {
                Helper.ShowError("Employee Exist. No need to Create Another one.");
                var confirm = await Helper.Confirmation("Do you wish to try again? (Y/N)");
                if (!confirm)
                {
                    Helper.ShowMsg("Returning back to the menu.");
                    Thread.Sleep(3000);
                    return;
                }
                continue;
            }
            // ID == -1 THEN CREATE EMPLOYEE
            Employee? emp = await _empRepo.CreateEmployee(new CreateEmpDTO { FirstName = firstName, LastName = lastName });
            if (emp.Id != 0)
            {
                AnsiConsole.Write("Welcome :"); Helper.DisplayFullName(emp);
                var confirm = await Helper.Confirmation("Create Another Employee?");
                if (confirm) continue;
                Helper.ShowMsg("Returning back to the menu.");
                return;
            }
        }
    }

    private async Task DisplayAllEmployees()
    {
        ListEmployees(await _empRepo.GetAllEmployees());
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
