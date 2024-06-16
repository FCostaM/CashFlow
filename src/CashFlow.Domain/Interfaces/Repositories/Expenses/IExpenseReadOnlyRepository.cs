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

    /// <summary>
    /// Retrieves a list of expenses filtered by a date range.
    /// </summary>
    /// <param name="startDate">The start date of the filter range.</param>
    /// <param name="endDate">The end date of the filter range.</param>
    /// <returns>A task that represents the asynchronous operation, containing a list of expenses that fall within the specified date range.</returns>
    Task<List<Expense>> FilterExpenseByDate(DateTime startDate, DateTime endDate);
}
