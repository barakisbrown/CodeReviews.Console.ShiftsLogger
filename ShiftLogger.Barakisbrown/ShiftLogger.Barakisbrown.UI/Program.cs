
using ShiftLogger.Barakisbrown.UI.Repos;

var repo = new EmployeeRepo();

var emps = await repo.GetEmployeesAsync();

Console.WriteLine($"Is emps null? {emps==null}");
Console.WriteLine($"There are currently {emps.Count} employees");

var index = 1;
foreach(var emp in emps)
{
    Console.WriteLine($"Employee {index}\tFirst Name = {emp.FirstName} \t Last Name = {emp.LastName}");
    index++;
}

int firstID = 1, secondID = 4;

var emp1 = await repo.GetEmployeeById(firstID);
var emp2 = await repo.GetEmployeeById(secondID);

Console.WriteLine($"Was the first one found? {(emp1 == null ? "Not Found" : "Found")}");
Console.WriteLine($"Was the first one found? {(emp2 == null ? "Not Found" : "Found")}");


Console.ReadKey(true);