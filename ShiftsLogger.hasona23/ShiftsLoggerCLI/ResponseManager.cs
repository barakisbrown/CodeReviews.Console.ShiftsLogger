﻿using System.Net.Http.Json;
using System.Text.Json;
using ShiftsLoggerCLI.Models;
using Spectre.Console;

namespace ShiftsLoggerCLI;

public static class ResponseManager
{
    private static readonly HttpClient Client ;

    static ResponseManager()
    {
        Uri baseUri = new("http://localhost:5105/");
        Client = new HttpClient();
        Client.BaseAddress = baseUri;
        PositionManager.SetPositions(GetAllWorkers().Result);
    }


   
    public static async Task<WorkerRead?> GetWorker(int id)
    {
        HttpResponseMessage response;
        try
        {
            response = await Client.GetAsync($"api/worker/{id}");
        }
        catch (HttpRequestException e)
        {
            AnsiConsole.MarkupLine($"[red]Request failed: [/]{e.Message}");
            MenuBuilder.EnterButtonPause();
            return null;
        }
        string json = await response.Content.ReadAsStringAsync();
        
        WorkerRead? worker = JsonSerializer.Deserialize<WorkerRead>(json)??null;

        return worker;
    }

    public static async Task DeleteWorker(int id)
    {
        HttpResponseMessage response;
        try
        {
            response = await Client.DeleteAsync($"api/worker/{id}");
        }
        catch (HttpRequestException e)
        {
            AnsiConsole.MarkupLine($"[red]Request failed: [/]{e.Message}");
            MenuBuilder.EnterButtonPause();
            
            return;
        }
        if (response.IsSuccessStatusCode)
        {
            AnsiConsole.MarkupLine("[green]Deleted worker successfully.[/]");
            MenuBuilder.EnterButtonPause();
            return;
        }
        AnsiConsole.MarkupLine("[red]Failed to delete worker.[/]");
        MenuBuilder.EnterButtonPause();
    }
    public static async Task<List<WorkerRead>> GetAllWorkers()
    {
        HttpResponseMessage response;
        try
        {
            response = await Client.GetAsync("api/worker/all");
        }
        catch (HttpRequestException e)
        {
            AnsiConsole.MarkupLine($"[red]Request failed: [/]{e.Message}");
            MenuBuilder.EnterButtonPause();
            return [];
        }
        string json = await response.Content.ReadAsStringAsync();
       
        List<WorkerRead> workers = JsonSerializer.Deserialize<List<WorkerRead>>(json) ?? [];
        
        return workers;
    }

    public static async Task UpdateWorker(WorkerUpdate worker)
    {
        HttpResponseMessage response;

        try
        {
            response = await Client.PutAsJsonAsync($"api/worker/{worker.Id}", worker);
        }
        catch (HttpRequestException e)
        {
            AnsiConsole.MarkupLine($"[red]Request failed: [/]{e.Message}");
            MenuBuilder.EnterButtonPause();
            return;
        }
        if (response.IsSuccessStatusCode)
        {
            AnsiConsole.MarkupLine("[green]Updated worker successfully.[/]");
            MenuBuilder.EnterButtonPause();
            return;
        }
        AnsiConsole.MarkupLine("[red]Failed to update worker.[/]");
        MenuBuilder.EnterButtonPause();
    }
    public static async Task AddWorker(WorkerCreate worker)
    {
        HttpResponseMessage response;
        try
        {
            response = await Client.PostAsJsonAsync("api/Worker", worker);
        }
        catch (HttpRequestException e)
        {
            AnsiConsole.MarkupLine($"[red]Request failed: [/]{e.Message}");
            MenuBuilder.EnterButtonPause();
            return;
        }
        Console.WriteLine(response.IsSuccessStatusCode ? "Worker added" : response.Content.ReadAsStringAsync().Result);
        MenuBuilder.EnterButtonPause();
    }

    public static async Task AddShift(ShiftCreate shift)
    {
        HttpResponseMessage response;
        try
        {
            response = await Client.PutAsJsonAsync("api/shift", shift);
        }
        catch (HttpRequestException e)
        {
            AnsiConsole.MarkupLine($"[red]Request failed:[/] {e.Message}");
            MenuBuilder.EnterButtonPause();
            return;
        }
        if (response.IsSuccessStatusCode)
        {
            AnsiConsole.MarkupLine("[green]Added Shift Successfully.[/]");
            MenuBuilder.EnterButtonPause();
            return;
        }   
        AnsiConsole.MarkupLine("[red]Failed to add Shift.[/]");
        MenuBuilder.EnterButtonPause();
        
    }

    public static async Task DeleteShift(int shiftId)
    {
        HttpResponseMessage response;
        try
        {
            response = await Client.DeleteAsync($"api/shifts/{shiftId}");
        }
        catch (HttpRequestException e)
        {
            AnsiConsole.MarkupLine($"[red]Request failed: [/]{e.Message}");
            MenuBuilder.EnterButtonPause();
            return;
        }

        if (response.IsSuccessStatusCode)
        {
            AnsiConsole.MarkupLine("[green]Deleted Shift successfully.[/]");
            MenuBuilder.EnterButtonPause();
            return;
        }
        AnsiConsole.MarkupLine("[red]Failed to delete Shift.[/]");
        MenuBuilder.EnterButtonPause();
    }

    public static async Task UpdateShift(ShiftUpdate shift)
    {

        HttpResponseMessage response;
        try
        {
            response = await Client.PutAsJsonAsync($"api/shifts", shift);
        }
        catch (HttpRequestException e)
        {
            AnsiConsole.MarkupLine($"[red]Request failed: [/]{e.Message}");
            MenuBuilder.EnterButtonPause();
            return;
        }
        if (response.IsSuccessStatusCode)
        {
            AnsiConsole.MarkupLine("[green]Updated Shift Successfully.[/]");
            MenuBuilder.EnterButtonPause();
            return;
        }
        AnsiConsole.MarkupLine("[red]Failed to update Shift.[/]");
        MenuBuilder.EnterButtonPause();
    }

    

    public static async Task<List<ShiftRead>> GetAllShifts()
    {
        HttpResponseMessage response;
        try
        {
             response = await Client.GetAsync("api/shifts/all");
        }
        catch (HttpRequestException e)
        {
            AnsiConsole.MarkupLine($"[red]Request failed: [/]{e.Message}");
            MenuBuilder.EnterButtonPause();
            return [];
        }

        var shifts = JsonSerializer.Deserialize<List<ShiftRead>>(await response.Content.ReadAsStringAsync())??new();
        return shifts;
    }
    public static async Task<List<ShiftRead>> GetShiftsByWorkerId(int workerId)
    {
        HttpResponseMessage response ;
        try
        {
            response = await Client.GetAsync($"api/shifts/{workerId}");
        }
        catch (HttpRequestException e)
        {
            AnsiConsole.MarkupLine($"[red]Request failed: [/]{e.Message}");
            MenuBuilder.EnterButtonPause();
            return [];
        }
        string json = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(json))
            return [];
        var shifts = JsonSerializer.Deserialize<List<ShiftRead>>(json) ?? new();
        return shifts;
    }
}