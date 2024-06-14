using CashFlow.Communication.Responses;

namespace CashFlow.Application.Interfaces.Expenses;

/// <summary>
/// Defines the contract for a use case to retrieve all expenses.
/// </summary>
public interface IGetAllExpensesUseCase
{
    /// <summary>
    /// Executes the use case to retrieve all expenses.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing the response with the list of expenses.</returns>
    Task<GetExpensesResponse> Execute();
}
