using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.Interfaces;

/// <summary>
/// Defines the contract for a use case to retrieve an expense by its ID.
/// </summary>
public interface IGetExpenseByIdUseCase
{
    /// <summary>
    /// Executes the use case to retrieve an expense by its ID.
    /// </summary>
    /// <param name="id">The ID of the expense to be retrieved.</param>
    /// <returns>A task that represents the asynchronous operation, containing the expense response if found.</returns>
    Task<ExpenseResponse> Execute(long id);
}
