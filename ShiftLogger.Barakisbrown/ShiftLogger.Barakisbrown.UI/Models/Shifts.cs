using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftLogger.Barakisbrown.UI.Models;

public class Shifts
{
    public int Id { get; set; }

    public DateTime BeginShift { get; set; }

    public DateTime EndShift { get; set; }

    // FOREIGN KEY
    public int EmployeeID { get; set; }

    // Required Reference navigation to principal
    public Employee Employee { get; set; } = null!;
}
