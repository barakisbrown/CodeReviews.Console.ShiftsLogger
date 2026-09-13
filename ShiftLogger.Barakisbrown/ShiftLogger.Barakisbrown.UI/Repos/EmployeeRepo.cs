using Mapster;
using Microsoft.Extensions.Logging;
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
    private ILogger<EmployeeRepo> _log;

    private IHttpClientFactory _factory;

    private HttpClient client;

    public EmployeeRepo(IHttpClientFactory httpClientFactory,ILogger<EmployeeRepo> logger)
    {
        url_getAll = "http://localhost:5012/api/employee/";
        url_getSingle = "http://localhost:5012/api/employee/";
        url_post = "http://localhost:5012/api/employee/";
        _log = logger;
        _factory = httpClientFactory;
    }

    public async Task<Employee?> CreateEmployee(CreateEmpDTO empDTO)
    {
        Employee ?newEmployee = null;
        try
        {
            client = _factory.CreateClient();
            Employee created = empDTO.Adapt<Employee>();

            HttpResponseMessage response = await client.PostAsJsonAsync(url_post, created);

            newEmployee = await response.Content.ReadFromJsonAsync<Employee ?>();
        }
        catch (HttpRequestException e)
        {
            _log.LogError("Could not create an employee due to exception thrown.", e.Message, e);

            Helper.ShowException(e);
        }

        return newEmployee;
    }

    public async Task<EmployeeDTO ?> GetEmployeeById(int id)
    {
        client = _factory.CreateClient();
        url_getSingle += id.ToString();
        client.BaseAddress = new Uri(url_getSingle);

        HttpResponseMessage message = await client.GetAsync(url_getSingle);

        if (message.StatusCode == HttpStatusCode.NotFound)
        {
            Helper.ShowNotFound();
            return null;
        }

        var emp = await client.GetFromJsonAsync<Employee>("");
        return emp.Adapt<EmployeeDTO>();


    }

    public async Task<List<EmployeeDTO ?>> GetAllEmployees()
    {
        List<EmployeeDTO?> emps = [];
        List<Employee>? employees = [];
        try
        {
            client = _factory.CreateClient();
            client.BaseAddress = new Uri(url_getAll);
            employees = await client.GetFromJsonAsync<List<Employee>>("");
            if (employees == null)
            {                
                throw new NullReferenceException("employee collection  is null");                
            }
            
            foreach(var single in employees)
            {
                emps.Add(single.Adapt<EmployeeDTO>());
            }
        }
        catch (HttpRequestException ext) 
        {
            switch(ext.HttpRequestError)
            {
                case HttpRequestError.ConnectionError:
                    _log.LogCritical($"Error Message Thrown is {ext.Message}", ext);
                    throw;
            }
        }catch(NullReferenceException nxt)
        {
            _log.LogTrace(nxt, "Collection was null");
            throw;
        }

        return emps;
    }

    public async Task<int> GetEmployeeID(CreateEmpDTO empDTO)
    {
        List<EmployeeDTO ?> employees = await GetAllEmployees();
        var exist = employees.FirstOrDefault(e => e.FirstName.Equals(empDTO.FirstName) && e.LastName.Equals(empDTO.LastName));

        return (exist == null) ? -1 : exist.Id;
    }
}
