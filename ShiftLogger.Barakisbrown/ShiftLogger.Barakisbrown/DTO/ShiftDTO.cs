namespace ShiftLogger.Barakisbrown.DTO;

public class ShiftDTO
{
    public int Id { get; set; }
    public DateTime BeginShift { get; set; } = DateTime.Now;

    public DateTime EndShift { get; set; } = DateTime.Now;

    public int EmployeeId { get; set; }

}
