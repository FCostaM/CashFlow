using CashFlow.Communication.Requests;

namespace CashFlow.Application.Interfaces;

public interface IUpdateExpenseUseCase
{
    Task Execute(long id, ExpenseRequest request);
}
