namespace ShiftLogger.Barakisbrown.Models;

public class Shifts
{
    public int Id {get;set;}

    public DateTime BeginShift {get;set;}
    public DateTime EndShift {get;set;}

    public int EmployeeID {get;set;}
}