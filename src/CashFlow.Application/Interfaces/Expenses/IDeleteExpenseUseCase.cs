namespace CashFlow.Application.Interfaces.Expenses;

/// <summary>
/// Defines the contract for a use case to delete an expense.
/// </summary>
public interface IDeleteExpenseUseCase
{
    /// <summary>
    /// Executes the use case to delete an expense by its ID.
    /// </summary>
    /// <param name="id">The ID of the expense to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Execute(long id);
}
