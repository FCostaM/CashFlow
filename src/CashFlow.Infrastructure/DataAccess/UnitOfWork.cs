using CashFlow.Domain.Interfaces;

namespace CashFlow.Infrastructure.DataAccess;

/// <summary>
/// Represents a unit of work for database operations.
/// </summary>
internal class UnitOfWork : IUnitOfWork
{
    /// <summary>
    /// Represents the database context used for database operations.
    /// </summary>
    private readonly CashFlowDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class using the specified database context.
    /// </summary>
    /// <param name="dbContext">The database context used for database operations.</param>
    public UnitOfWork(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Saves the changes made in the unit of work to the database.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
