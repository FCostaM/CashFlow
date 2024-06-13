using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;

/// <summary>
/// Represents the database context for the application.
/// </summary>
public class CashFlowDbContext : DbContext
{
    /// <summary>
    /// Represents the DbSet of expenses in the database.
    /// </summary>
    public DbSet<Expense> Expenses { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CashFlowDbContext"/> class using the specified options.
    /// </summary>
    /// <param name="options">The options to be used by the context.</param>
    public CashFlowDbContext(DbContextOptions options) : base(options) { }
}
