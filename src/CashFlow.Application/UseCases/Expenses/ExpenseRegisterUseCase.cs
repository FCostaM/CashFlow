using AutoMapper;
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
    private readonly IMapper _mapper;

    public ExpenseRegisterUseCase(
        IExpenseRepository repository, 
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ExpenseResponse> Execute(ExpenseRegisterRequest request)
    {
        Validate(request);

        var entity = _mapper.Map<Expense>(request);

        await _repository.AddExpense(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ExpenseResponse>(entity);
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
