using CashFlow.Application.Validators;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Exception.CustomExceptions;
using CashFlow.Infrastructure.DataAccess;

namespace CashFlow.Application.UseCases.Expenses;

public class ExpenseRegisterUseCase
{
    public ExpenseResponse Execute(ExpenseRegisterRequest request)
    {
        Validate(request);

        var dbContext = new CashFlowDbContext();

        var entity = new Expense
        {
            Title = request.Title,
            Description = request.Description,
            Date = request.Date,
            Amount = request.Amount,
            PaymentType = (Domain.Enums.PaymentType)request.PaymentType
        };

        dbContext.Add(entity);

        dbContext.SaveChanges();

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
