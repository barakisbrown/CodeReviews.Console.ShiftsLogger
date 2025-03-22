using ShiftLogger.Barakisbrown.DataLayer;
using ShiftLogger.Barakisbrown.Models;

namespace ShiftLogger.Barakisbrown.Services;

internal class EmployeeService(ShiftContext shiftContext) : IEmployeeService
{
    private readonly ShiftContext _shiftContext = shiftContext;

    /// <summary>
    /// Adds a new employee with its first and last name
    /// </summary>
    /// <param name="firstName">First Name</param>
    /// <param name="lastName">Last Name</param>
    /// <returns>true if added. False if Employee already Exist. </returns>
    /// <exception cref="NotImplementedException"></exception>
    public bool AddEmployee(string firstName, string lastName)
    {
        if (firstName.Equals("") && lastName.Equals(""))
            return false;

        Employee employee = new Employee { FirstName = firstName, LastName = lastName };

        var found = _shiftContext.Find<Employee>(employee);

        if (found == null) return false;

        _shiftContext.Add(employee);
        return (_shiftContext.SaveChanges() ==1 );
    }


    /// <summary>
    /// Fethes all Employee and then returns them as a list
    /// </summary>
    /// <returns>List of Employees</returns>
    /// <exception cref="NotImplementedException"></exception>
    public List<Employee> GetAllEmployees()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Fetches all shifts for a particular Employee and then returns those shifts
    /// </summary>
    /// <param name="Id">The employee id that function needs to fetch</param>
    /// <returns>List of Shifts belonging to the Employee in question OR Null if Employee is not found</returns>
    /// <exception cref="NotImplementedException"></exception>
    public List<Shifts> GetAllShifts(int employeeId)
    {
        throw new NotImplementedException();
    }


    /// <summary>
    /// Removes Employee from the database and all shifts that belong to that Employee
    /// </summary>
    /// <param name="removedId">Id of the employee that needs to be removed</param>
    /// <returns>True if successful or false otherwise</returns>
    /// <exception cref="NotImplementedException"></exception>
    public bool RemoveEmployee(int removedId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates the Employee in question either by his first or lastname or both.
    /// if first/last is null, then field is not updated
    /// 
    /// </summary>
    /// <param name="updatedId">Employee ID that needs data updated</param>
    /// <param name="firstName">Employee First Name to be updated IF is it not NULL</param>
    /// <param name="lastName">Employee Last Name to be updated IF is it not NULL</param>
    /// <returns>True if successful or false if not updated</returns>
    /// <exception cref="NotImplementedException"></exception>
    public bool UpdateEmployee(int updatedId, string ?firstName, string ?lastName)
    {
        throw new NotImplementedException();
    }
}
