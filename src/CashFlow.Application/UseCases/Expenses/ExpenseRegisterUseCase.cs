using CashFlow.Application.Interfaces;
using CashFlow.Application.Validators;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Exception.CustomExceptions;

namespace CashFlow.Application.UseCases.Expenses;

public class ExpenseRegisterUseCase : IExpenseRegisterUseCase
{
    private readonly IExpenseRepository _repository;

    public ExpenseRegisterUseCase(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public ExpenseResponse Execute(ExpenseRegisterRequest request)
    {
        Validate(request);

        var entity = new Expense
        {
            Title = request.Title,
            Description = request.Description,
            Date = request.Date,
            Amount = request.Amount,
            PaymentType = (Domain.Enums.PaymentType)request.PaymentType
        };

        _repository.AddExpense(entity);

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
