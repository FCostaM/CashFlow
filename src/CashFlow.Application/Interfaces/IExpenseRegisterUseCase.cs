using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.Interfaces;

/// <summary>
/// Defines the contract for a use case to register a new expense.
/// </summary>
public interface IExpenseRegisterUseCase
{
    /// <summary>
    /// Executes the use case to register a new expense.
    /// </summary>
    /// <param name="request">The request containing the expense details.</param>
    /// <returns>The response containing the registered expense details.</returns>
    Task<ExpenseRegisterResponse> Execute(ExpenseRequest request);
}
