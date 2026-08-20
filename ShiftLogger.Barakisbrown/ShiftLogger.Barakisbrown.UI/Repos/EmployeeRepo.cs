using ShiftLogger.Barakisbrown.UI.Interfaces;
using ShiftLogger.Barakisbrown.UI.Models;
using System.Net;
using System.Net.Http.Json;

namespace ShiftLogger.Barakisbrown.UI.Repos;

public class EmployeeRepo : IEmployeeRepo
{
    private string url_getAll = "";
    private string url_getSingle = "";

    private HttpClient client;

    public EmployeeRepo()
    {
        url_getAll = "http://localhost:5012/api/employee/";
        url_getSingle = "http://localhost:5012/api/employee/";
    }

    public async Task<Employee> GetEmployeeById(int id)
    {
        url_getSingle += id.ToString();
        client = new()
        {
            BaseAddress = new Uri(url_getSingle)
        };

        HttpResponseMessage message = await client.GetAsync(url_getSingle);

        if (message.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        var emp = await client.GetFromJsonAsync<Employee>("");
        return emp;


    }

    public async Task<List<Employee ?>> GetEmployeesAsync()
    {
        client = new() 
        {
            BaseAddress = new Uri(url_getAll)
        };

        var emps = await client.GetFromJsonAsync<List<Employee>>("");
        if (emps == null) return null;
        return emps;
    }
}
