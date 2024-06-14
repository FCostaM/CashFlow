using CashFlow.Communication.Requests;

namespace CashFlow.Application.Interfaces.Expenses;

/// <summary>
/// Defines the contract for a use case to update an existing expense.
/// </summary>
public interface IUpdateExpenseUseCase
{
    /// <summary>
    /// Executes the use case to update an existing expense.
    /// </summary>
    /// <param name="id">The ID of the expense to be updated.</param>
    /// <param name="request">The request containing updated expense details.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task Execute(long id, ExpenseRequest request);
}
