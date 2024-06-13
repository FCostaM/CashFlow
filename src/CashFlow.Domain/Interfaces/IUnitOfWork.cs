namespace CashFlow.Domain.Interfaces;

/// <summary>
/// Defines the interface for a unit of work that handles committing transactions.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Saves all changes made within the current transaction scope.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task Commit();
}
