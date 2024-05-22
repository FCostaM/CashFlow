using CashFlow.Application.Validators;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.BaseExceptions;

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
        var validation = new ExpenseRegisterValidator().Validate(request);

        if (validation.IsValid == false)
        {
            var errosMessages = validation.Errors
                .Select(f => f.ErrorMessage)
                .ToList();

            throw new ErrorOnValidationException(errosMessages);
        }
    }
}
