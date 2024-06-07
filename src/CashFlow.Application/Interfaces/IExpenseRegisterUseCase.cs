using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.Interfaces;

public interface IExpenseRegisterUseCase
{
    Task<ExpenseResponse> Execute(ExpenseRegisterRequest request);
}
