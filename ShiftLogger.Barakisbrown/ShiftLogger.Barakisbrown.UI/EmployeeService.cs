// <copyright file="EmployeeService.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>

namespace ShiftLogger.Barakisbrown.UI;

using Microsoft.Extensions.Logging;
using ShiftLogger.Barakisbrown.UI.DTO;
using ShiftLogger.Barakisbrown.UI.Interfaces;
using ShiftLogger.Barakisbrown.UI.Models;
using ShiftLogger.Barakisbrown.UI.UserInput;
using Spectre.Console;

/// <summary>
/// Service for using with employees such as creating.
/// Editing or deleting Employees.
/// </summary>
public class EmployeeService : IService
{
    private readonly IEmployeeRepo empRepo;
    private readonly IShiftRepo shiftRep;
    private readonly ILogger<App> logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmployeeService"/> class.
    /// </summary>
    /// <param name="empRepo">employee repo interface.</param>
    /// <param name="shiftRepo">shift repo interface.</param>
    /// <param name="logger">ILogger interface.</param>
    public EmployeeService(
    IEmployeeRepo empRepo, IShiftRepo shiftRepo, ILogger<App> logger)
    {
        this.empRepo = empRepo;
        this.shiftRep = shiftRepo;
        this.logger = logger;
    }

    /// <summary>
    /// Displays a title to the screen with or without app version.
    /// </summary>
    /// <param name="sectionName">The title being displayed.</param>
    /// <param name="appVersion">if null then shows nothing otherwise show the appversion.</param>
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
            .Color(Color.Blue));
        }
    }

    /// <summary>
    /// This launches the application.
    /// </summary>
    /// <returns> async.</returns>
    public async Task Run()
    {
        bool exit = false;
        while (!exit)
        {
            AnsiConsole.Clear();
            Title("Employee Section", "1.0.0");
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
#pragma warning disable SA1001 // CommasMustBeSpacedCorrectly
            var choices = await AnsiConsole.PromptAsync(Helper.ShowMenuChoices("Select Option", [1, 2, 3, 4, 5, 6]));
            switch (choices)
            {
                case 1:
                    await this.CreateUser();
                    Thread.Sleep(2000);
                    break;
                case 2:
                case 3:
                    Helper.ShowMsg($"[yellow]Not implemented yet[/]");
                    Thread.Sleep(3000);
                    break;
                case 4:
                    await this.DeleteEmployees();
                    break;
                case 5:
                    await this.DisplayAllEmployees();
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
        {
            Helper.ShowMsg("There are currently 0 Employees");
        }
        else
        {
            AnsiConsole.Clear();
            var table = new Table();
            table.Title($"{employees.Count} Employees Listed");
            table.AddColumn("First Name");
            table.AddColumn("Last Name");

            foreach (EmployeeDTO? emp in employees)
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
            Title("Create Employee Section", null);
            AnsiConsole.WriteLine();

            // FETCH First and Last Name
            var firstName = await AnsiConsole.PromptAsync(
                new TextPrompt<string>("First Name -> "));
            var lastName = await AnsiConsole.PromptAsync(
                new TextPrompt<string>("Last Name -> "));

            // DO THEY EXIST?
            var id = await this.empRepo.GetEmployeeID(new CreateEmpDTO { FirstName = firstName, LastName = lastName });
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
            Employee? emp = await this.empRepo.CreateEmployee(new CreateEmpDTO { FirstName = firstName, LastName = lastName });
            if (emp.Id != 0)
            {
                AnsiConsole.Write("Welcome :");
                Helper.DisplayFullName(emp);
                var confirm = await Helper.Confirmation("Create Another Employee?");
                if (confirm)
                {
                    continue;
                }

                Helper.ShowMsg("Returning back to the menu.");
                return;
            }
        }
    }

    private async Task DisplayAllEmployees()
    {
        ListEmployees(await this.empRepo.GetAllEmployees());
    }

    private async Task SearchEmployees()
    {

    }

    private async Task UpdateEmployees()
    {

    }

    private async Task DeleteEmployees()
    {
        List<EmployeeDTO?> employees = await this.empRepo.GetAllEmployees();

        bool complete = false;
        while (!complete)
        {
            AnsiConsole.Clear();
            Helper.ShowMsg("Delete Employee Section.");
            Helper.ShowMsg("Please be careful here because you can not undo any changes made. All changes are permenant.");
            Helper.ShowMsg("Note: Default User can not be deleted.");
            Helper.ShowMsg(string.Empty);
            var deletedEmp = await Helper.GetUserInfo(employees);
            var deletedMsg = $"[red]Do you wish to delete this user {deletedEmp.FirstName + " " + deletedEmp.LastName}[/]";
            if (deletedEmp.Id == -1)
            {
                break;
            }

            var confirm = await Helper.Confirmation(deletedMsg);
            if (confirm)
            {
                var del = this.empRepo.DeleteEmployee(deletedEmp);
                if (del != null)
                {
                    Helper.ShowError($"Deleting Employee {deletedEmp.FullName}");
                    var leave = await Helper.Confirmation("Do you wish to delete another employee?");
                    if (leave)
                    {
                        Helper.ShowMsg("Exiting the delete employee selection");
                        Thread.Sleep(2000);
                        break;
                    }
                }
            }
            else
            {
                Helper.ShowMsg("Employee was not deleted.");
            }

            Thread.Sleep(2000);
        }
    }

}
