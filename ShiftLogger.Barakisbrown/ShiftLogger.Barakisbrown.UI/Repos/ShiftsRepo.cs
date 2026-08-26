using ShiftLogger.Barakisbrown.UI.Interfaces;
using ShiftLogger.Barakisbrown.UI.Models;
using ShiftLogger.Barakisbrown.UI.UserInput;
using Spectre.Console;
using System.Net.Http.Json;

namespace ShiftLogger.Barakisbrown.UI.Repos;

public class ShiftsRepo : IShiftRepo
{
    private int portNumber = 5012;
    private string baseUrl;

    private HttpClient client;

    public ShiftsRepo()
    {
        baseUrl = $"http://localhost:{portNumber}/api/shift/";
    }

    public async Task<List<Shifts ?>> GetAllShiftsAsync()
    {
        client = new()
        {
            BaseAddress = new Uri(baseUrl),
        };

        HttpResponseMessage message = await client.GetAsync(baseUrl);

        if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            Helper.ShowNotFound();
            return null;
        }

       
        List<Shifts?>? shifts = await client.GetFromJsonAsync<List<Shifts ?>>("");
        if (shifts == null) return null;
        return shifts;
    }
}
