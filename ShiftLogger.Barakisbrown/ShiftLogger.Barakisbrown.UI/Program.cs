
using ShiftLogger.Barakisbrown.UI.DTO;
using ShiftLogger.Barakisbrown.UI.Repos;
using ShiftLogger.Barakisbrown.UI.UserInput;

var empRepo = new EmployeeRepo();
var shiftRepo = new ShiftsRepo();

var list = await empRepo.GetEmployeesAsync();

Helper.ShowMsg($"There are currently {list.Count} employees");
foreach (var emp in list)
{
    Helper.DisplayFullName(emp);
}













Console.ReadKey(true);