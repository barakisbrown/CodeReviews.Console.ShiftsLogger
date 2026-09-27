// <copyright file="App.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>
namespace ShiftLogger.Barakisbrown.UI;

using Microsoft.Extensions.Logging;
using ShiftLogger.Barakisbrown.UI.DTO;
using ShiftLogger.Barakisbrown.UI.Interfaces;
using ShiftLogger.Barakisbrown.UI.UserInput;
using Spectre.Console;

/// <summary>
/// Class which will launch the UI part of the.
/// </summary>
public class App : IService
{
    private IEmployeeRepo empRepo;
    private IShiftRepo shiftRepo;
    private ILogger<App> logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <param name="empRepo">employee Repo interface.</param>
    /// <param name="shiftRepo">shift repo interface.</param>
    /// <param name="logger">ILogger interface.</param>
    public App(
        IEmployeeRepo empRepo, IShiftRepo shiftRepo, ILogger<App> logger)
    {
        this.empRepo = empRepo;
        this.shiftRepo = shiftRepo;
        this.logger = logger;
    }

    /// <summary>
    /// Displays a title with an appversion to the screen.
    /// </summary>
    /// <param name="sectionName">name of the title displayed.</param>
    /// <param name="appVersion">if null displays nothing, if not null then display version.</param>
    public static void Title(string sectionName, string? appVersion)
    {
        AnsiConsole.Write(
              renderable: new FigletText(sectionName)
              .Centered().Color(Color.Blue));

        if (appVersion is not null)
        {
            AnsiConsole.Write(
                new FigletText(appVersion)
                .Centered()
                .Color(Color.Blue));
        }
    }

    /// <summary>
    /// Launch point for the ui application.
    /// </summary>
    /// <returns>async.</returns>
    public async Task Run()
    {
        await this.DisplayMenu();
        /*try
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
        }*/
    }

    private async Task DisplayMenu()
    {
        bool exit = false;
        while (!exit)
        {
            AnsiConsole.Clear();
            Title("Shift Logger Application", "1.0.0");
            await Console.Out.WriteLineAsync();
            Helper.ShowMsg("Application Main Menu");
            Helper.ShowMsg("----------------------");
            Helper.ShowMsg("1. Employee Section   ");
            Helper.ShowMsg("2. Shifts Section     ");
            Helper.ShowMsg("3. Exit Shift Logger  ");
            Helper.ShowMsg("----------------------");
            #pragma warning disable SA1001 // CommasMustBeSpacedCorrectly
            var choices = await AnsiConsole.PromptAsync(Helper.ShowMenuChoices("Select Option",[1, 2, 3]));
            switch (choices)
            {
                case 1:
                    EmployeeService service = new EmployeeService(this.empRepo, this.shiftRepo, this.logger);
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
}