using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces.Repositories.Expenses;

/// <summary>
/// Provides read-only operations for managing expenses.
/// </summary>
public interface IExpenseReadOnlyRepository
{
    /// <summary>
    /// Retrieves all expenses from the database.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, containing a list of all expenses.</returns>
    Task<List<Expense>> GetAllExpenses();

    /// <summary>
    /// Retrieves an expense by its ID without tracking the entity.
    /// </summary>
    /// <param name="id">The ID of the expense to be retrieved.</param>
    /// <returns>A task that represents the asynchronous operation, containing the expense if found; otherwise, null.</returns>
    Task<Expense?> GetExpenseById(long id);

    /// <summary>
    /// Retrieves an expense by its ID for update purposes, with tracking enabled.
    /// </summary>
    /// <param name="id">The ID of the expense to be retrieved for update.</param>
    /// <returns>A task that represents the asynchronous operation, containing the expense if found; otherwise, null.</returns>
    Task<Expense?> GetExpenseForUpdate(long id);
}
