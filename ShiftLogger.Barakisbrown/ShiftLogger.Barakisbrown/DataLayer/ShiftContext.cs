namespace ShiftLogger.Barakisbrown.DataLayer;

using Microsoft.EntityFrameworkCore;
using Models;

internal class ShiftContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Shifts> Shifts { get; set; }
    
    public ShiftContext() { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.shifts)
            .WithOne(o => o.Employee)
            .HasForeignKey(e => e.EmployeeID)
            .IsRequired();
    }
}
