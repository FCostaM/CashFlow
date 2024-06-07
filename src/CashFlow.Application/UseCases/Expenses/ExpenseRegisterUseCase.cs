using CashFlow.Application.Interfaces;
using CashFlow.Application.Validators;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Exception.CustomExceptions;

namespace CashFlow.Application.UseCases.Expenses;

public class ExpenseRegisterUseCase : IExpenseRegisterUseCase
{
    private readonly IExpenseRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ExpenseRegisterUseCase(IExpenseRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ExpenseResponse> Execute(ExpenseRegisterRequest request)
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

        await _repository.AddExpense(entity);

        await _unitOfWork.Commit();

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
