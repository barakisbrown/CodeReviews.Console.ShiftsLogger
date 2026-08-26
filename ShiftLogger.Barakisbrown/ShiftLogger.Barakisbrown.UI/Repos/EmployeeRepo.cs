using Mapster;
using ShiftLogger.Barakisbrown.UI.DTO;
using ShiftLogger.Barakisbrown.UI.Interfaces;
using ShiftLogger.Barakisbrown.UI.Models;
using ShiftLogger.Barakisbrown.UI.UserInput;
using System.Net;
using System.Net.Http.Json;

namespace ShiftLogger.Barakisbrown.UI.Repos;

public class EmployeeRepo : IEmployeeRepo
{
    private string url_getAll = string.Empty;
    private string url_getSingle = string.Empty;
    private string url_post = string.Empty;

    private HttpClient client = new();

    public EmployeeRepo()
    {
        url_getAll = "http://localhost:5012/api/employee/";
        url_getSingle = "http://localhost:5012/api/employee/";
        url_post = "http://localhost:5012/api/employee/";
    }

    public async Task<Employee?> CreateEmployee(CreateEmpDTO empDTO)
    {
        Employee ?newEmployee = null;
        try
        {
            Employee created = empDTO.Adapt<Employee>();

            HttpResponseMessage response = await client.PostAsJsonAsync(url_post, created);

            newEmployee = await response.Content.ReadFromJsonAsync<Employee ?>();
        }
        catch (HttpRequestException e)
        {

            Helper.ShowException(e);
        }

        return newEmployee;
    }

    public async Task<Employee ?> GetEmployeeById(int id)
    {
        url_getSingle += id.ToString();
        client.BaseAddress = new Uri(url_getSingle);

        HttpResponseMessage message = await client.GetAsync(url_getSingle);

        if (message.StatusCode == HttpStatusCode.NotFound)
        {
            Helper.ShowNotFound();
            return null;
        }

        var emp = await client.GetFromJsonAsync<Employee>("");
        return emp;


    }

    public async Task<List<Employee ?>> GetEmployeesAsync()
    {
        client.BaseAddress = new Uri(url_getAll);
        var emps = await client.GetFromJsonAsync<List<Employee>>("");
        if (emps == null) return null;
        return emps;
    }
}
