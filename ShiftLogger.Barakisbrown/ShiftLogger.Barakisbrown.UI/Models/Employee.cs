using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftLogger.Barakisbrown.UI.Models
{
    public  class Employee
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        // Required reference navigation to principle
        public ICollection<Shifts> shifts { get; set; } = new List<Shifts>();
    }
}
