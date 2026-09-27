// <copyright file="EmployeeRepo.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>
namespace ShiftLogger.Barakisbrown.UI.Repos;

using Mapster;
using Microsoft.Extensions.Logging;
using ShiftLogger.Barakisbrown.UI.DTO;
using ShiftLogger.Barakisbrown.UI.Interfaces;
using ShiftLogger.Barakisbrown.UI.Models;
using ShiftLogger.Barakisbrown.UI.UserInput;
using System.Net;
using System.Net.Http.Json;

/// <summary>
/// Reposoitory of Employee Functions.
/// </summary>
public class EmployeeRepo : IEmployeeRepo
{
    private readonly string urlGetAll = string.Empty;
    private readonly string urlPost = string.Empty;
    private readonly ILogger<EmployeeRepo> log;
    private readonly IHttpClientFactory factory;
    private string urlGetSingle = string.Empty;
    private HttpClient? client;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmployeeRepo"/> class.
    /// </summary>
    /// <param name="httpClientFactory">httpClientFactor Interface.</param>
    /// <param name="logger">ILogger Interface.</param>
    public EmployeeRepo(IHttpClientFactory httpClientFactory, ILogger<EmployeeRepo> logger)
    {
        this.urlGetAll = "http://localhost:5012/api/employee/";
        this.urlGetSingle = "http://localhost:5012/api/employee/";
        this.urlPost = "http://localhost:5012/api/employee/";
        this.log = logger;
        this.factory = httpClientFactory;
    }

    /// <summary>
    /// Returns a create employee or null if error appears.
    /// </summary>
    /// <param name="empDTO">Employee info to be created.</param>
    /// <returns>a employee just created.</returns>
    /// <exception cref="HttpRequestException"> If error occurs, return exception. </exception>
    public async Task<Employee?> CreateEmployee(CreateEmpDTO empDTO)
    {
        Employee? newEmployee = null;
        try
        {
            this.client = this.factory.CreateClient();
            Employee created = empDTO.Adapt<Employee>();

            HttpResponseMessage response = await this.client.PostAsJsonAsync(this.urlPost, created);

            newEmployee = await response.Content.ReadFromJsonAsync<Employee?>();
        }
        catch (HttpRequestException e)
        {
            this.log.LogError("Could not create an employee due to exception thrown.", e.Message, e);
            Helper.ShowException(e);
        }

        return newEmployee;
    }

    /// <summary>
    /// Returns an employee by its employee id.
    /// </summary>
    /// <param name="id">id of employee being searched.</param>
    /// <returns>EmployeeDTO of Employee Found or null.</returns>
    public async Task<EmployeeDTO?> GetEmployeeById(int id)
    {
        this.client = this.factory.CreateClient();
        this.urlGetSingle += id.ToString();
        this.client.BaseAddress = new Uri(this.urlGetSingle);

        HttpResponseMessage message = await this.client.GetAsync(this.urlGetSingle);

        if (message.StatusCode == HttpStatusCode.NotFound)
        {
            Helper.ShowNotFound();
            return null;
        }

        var emp = await this.client.GetFromJsonAsync<Employee>(string.Empty);
        return emp.Adapt<EmployeeDTO>();
    }

    /// <summary>
    /// Gets all the employees.
    /// </summary>
    /// <returns>A list of all Employees. If empty then NULL.</returns>
    /// <exception cref="HttpRequestException"> If error message when exception is thrown. </exception>
    /// <exception cref="NullReferenceException">If null is found.</exception>
    public async Task<List<EmployeeDTO?>> GetAllEmployees()
    {
#pragma warning disable SA1010 // OpeningSquareBracketsMustBeSpacedCorrectly
        List<EmployeeDTO?> emps = [];
        List<Employee>? employees = [];
#pragma warning disable SA1010 // OpeningSquareBracketsMustBeSpacedCorrectly
        try
        {
            this.client = this.factory.CreateClient();
            this.client.BaseAddress = new Uri(this.urlGetAll);
            employees = await this.client.GetFromJsonAsync<List<Employee>>(string.Empty);
            if (employees == null)
            {
                throw new NullReferenceException("employee collection  is null");
            }

            foreach (var single in employees)
            {
                emps.Add(single.Adapt<EmployeeDTO>());
            }
        }
        catch (HttpRequestException ext)
        {
            switch (ext.HttpRequestError)
            {
                case HttpRequestError.ConnectionError:
                    this.log.LogCritical($"Error Message Thrown is {ext.Message}", ext);
                    throw;
            }
        }
        catch (NullReferenceException nxt)
        {
            this.log.LogTrace(nxt, "Collection was null");
            throw;
        }

        return emps;
    }

    /// <summary>
    /// Gets EmployeeID based on CreateEmpDTO.
    /// </summary>
    /// <param name="empDTO">CreatedEmployeeDTO.</param>
    /// <returns>int which is the ID.</returns>
    public async Task<int> GetEmployeeID(CreateEmpDTO empDTO)
    {
        List<EmployeeDTO?> employees = await this.GetAllEmployees();
        var exist = employees.FirstOrDefault(e => e.FirstName.Equals(empDTO.FirstName) && e.LastName.Equals(empDTO.LastName));

        return (exist == null) ? -1 : exist.Id;
    }
}
