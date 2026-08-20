using ShiftLogger.Barakisbrown.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftLogger.Barakisbrown.UI.Interfaces;

public interface IEmployeeRepo
{
    public Task<List<Employee?>> GetEmployeesAsync();

    public Task<Employee> GetEmployeeById(int id);
}
