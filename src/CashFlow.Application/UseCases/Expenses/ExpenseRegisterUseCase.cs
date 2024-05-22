using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses;

public class ExpenseRegisterUseCase
{
    public ExpenseResponse Execute(ExpenseRegisterRequest request)
    {
        Validate(request);

        return new ExpenseResponse();
    }

    private void Validate(ExpenseRegisterRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentException("Title is required");
        }

        if (DateTime.Compare(request.Date, DateTime.UtcNow) > 0)
        {
            throw new ArgumentException("Expense cannot be for the future");
        }

        if (request.Amount <= 0)
        {
            throw new ArgumentException("Amount must be greater then zero");
        }

        if (Enum.IsDefined(typeof(PaymentType), request.PaymentType) == false)
        {
            throw new ArgumentException("Payment type is invalid");
        }
    }
}
