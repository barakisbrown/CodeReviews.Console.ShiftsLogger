using System;

namespace ShiftLogger.Barakisbrown.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName {get;set;}

    public string LastName {get;set;}

    public List<Shifts> Shifts  {get;set;}   
}
