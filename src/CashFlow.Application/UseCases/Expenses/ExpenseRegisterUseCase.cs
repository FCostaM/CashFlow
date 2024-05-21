using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses;

public class ExpenseRegisterUseCase
{
    public ExpenseResponse Execute(ExpenseRegisterRequest request)
    {
        return new ExpenseResponse();
    }
}
