namespace ShiftLogger.Barakisbrown.Models;

public class Employee
{
    public int Id { get; set; }

    public required string FirstName {get;set;}

    public required string LastName {get;set;}

    // Required reference navigation to principle
    public ICollection<Shifts> shifts { get;set;} = new List<Shifts>();
}
