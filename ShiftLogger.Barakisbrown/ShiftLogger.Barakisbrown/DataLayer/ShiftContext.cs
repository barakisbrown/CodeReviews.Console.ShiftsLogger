// <copyright file="ShiftContext.cs" company="barakisbrown">
// Copyright (c) barakisbrown. All rights reserved.
// </copyright>

namespace ShiftLogger.Barakisbrown.DataLayer;

using Microsoft.EntityFrameworkCore;
using Models;

/// <summary>
/// DB Context for the shift database.
/// </summary>
public class ShiftContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ShiftContext"/> class.
    /// </summary>
    /// <param name="options">DbContextOptions options to pass into the class.</param>
    #pragma warning disable SA1502 // ElementMustNotBeOnSingleLine
    public ShiftContext(DbContextOptions options)
     : base(options) { }

    /// <summary>
    /// Gets or Sets Employees.
    /// </summary>
    public DbSet<Employee> Employees { get; set; }

    /// <summary>
    /// Gets or Sets Shifts.
    /// </summary>
    public DbSet<Shifts> Shifts { get; set; }

    /// <summary>
    /// Helps create the 1 to many relationship in the db.
    /// </summary>
    /// <param name="modelBuilder">ModelBuilder class from etf.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Shifts)
            .WithOne(o => o.Employee)
            .HasForeignKey(e => e.EmployeeID)
            .IsRequired();
    }
}
