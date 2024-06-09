using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.Interfaces;

public interface IGetExpenseByIdUseCase
{
    Task<ExpenseResponse> Execute(long id);
}
