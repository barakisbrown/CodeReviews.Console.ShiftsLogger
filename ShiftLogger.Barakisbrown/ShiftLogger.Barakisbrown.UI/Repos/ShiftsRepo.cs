// <copyright file="ShiftsRepo.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>
namespace ShiftLogger.Barakisbrown.UI.Repos;

using Microsoft.Extensions.Logging;
using ShiftLogger.Barakisbrown.UI.Interfaces;
using ShiftLogger.Barakisbrown.UI.Models;
using ShiftLogger.Barakisbrown.UI.UserInput;
using System.Net.Http.Json;

/// <summary>
/// Reposository of functions related to shifts.
/// </summary>
public class ShiftsRepo : IShiftRepo
{
    private readonly ILogger<ShiftsRepo> log;
    private readonly int portNumber = 5012;
    private string baseUrl;

    private HttpClient client;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShiftsRepo"/> class.
    /// </summary>
    /// <param name="httpClientFactory">httpClientFacotry Interface.</param>
    /// <param name="logger">Ilogger interface.</param>
    public ShiftsRepo(IHttpClientFactory httpClientFactory, ILogger<ShiftsRepo> logger)
    {
        this.baseUrl = $"http://localhost:{this.portNumber}/api/shift/";
        this.client = httpClientFactory.CreateClient();
        this.log = logger;
    }

    /// <summary>
    /// Returns Null or List of all shifts.
    /// </summary>
    /// <returns>Null OR List of Shifts. </Shifts></returns>
    public async Task<List<Shifts?>> GetAllShiftsAsync()
    {
        this.client = new ()
        {
            BaseAddress = new Uri(this.baseUrl),
        };

        HttpResponseMessage message = await this.client.GetAsync(this.baseUrl);

        if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            Helper.ShowNotFound();
            return null;
        }

        List<Shifts?>? shifts = await this.client.GetFromJsonAsync<List<Shifts?>>(string.Empty);
        if (shifts == null)
        {
            return null;
        }

        return shifts;
    }
}
