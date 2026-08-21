namespace ShiftLogger.Barakisbrown.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public required string FirstName { get; set; } = string.Empty;
        public required string LastName { get; set; } = string.Empty;
    }
}
