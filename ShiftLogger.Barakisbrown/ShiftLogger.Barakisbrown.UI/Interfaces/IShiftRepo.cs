using ShiftLogger.Barakisbrown.UI.Models;

namespace ShiftLogger.Barakisbrown.UI.Interfaces;

public interface IShiftRepo
{
    Task<List<Shifts ?>> GetAllShiftsAsync();
}
