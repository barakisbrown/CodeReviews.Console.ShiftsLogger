namespace ShiftLogger.Barakisbrown.Models;

public class Shifts
{
    public int Id {get;set;}

    public DateTime BeginShift {get;set;}

    public DateTime EndShift {get;set;}

    // FOREIGN KEY
    public int EmployeeID { get; set; }

    // Required Reference navigation to principal
    public Employee Employee { get; set; } = null!;
}