using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces.Repositories.Expenses;

/// <summary>
/// Provides write-only operations for managing expenses.
/// </summary>
public interface IExpenseWriteOnlyRepository
{
    /// <summary>
    /// Adds a new expense to the database.
    /// </summary>
    /// <param name="expense">The expense entity to be added.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddExpense(Expense expense);

    /// <summary>
    /// Deletes an expense from the database based on its ID.
    /// </summary>
    /// <param name="id">The ID of the expense to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation, containing TRUE if the expense was found and deleted; otherwise, FALSE.</returns>
    Task<bool> DeleteExpense(long id);

    /// <summary>
    /// Updates an existing expense in the database.
    /// </summary>
    /// <param name="expense">The expense entity with updated values.</param>
    void UpdateExpense(Expense expense);
}
