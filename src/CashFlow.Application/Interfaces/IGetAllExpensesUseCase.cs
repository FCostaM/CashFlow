using CashFlow.Communication.Responses;

namespace CashFlow.Application.Interfaces;

public interface IGetAllExpensesUseCase
{
    Task<GetExpensesResponse> Execute();
}
