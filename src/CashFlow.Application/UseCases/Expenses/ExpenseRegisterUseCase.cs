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
    private readonly IExpenseWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ExpenseRegisterUseCase(IExpenseWriteOnlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ExpenseRegisterResponse> Execute(ExpenseRequest request)
    {
        Validate(request);

        var entity = _mapper.Map<Expense>(request);

        await _repository.AddExpense(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ExpenseRegisterResponse>(entity);
    }

    private void Validate(ExpenseRequest request)
    {
        var validation = new ExpenseValidator().Validate(request);

        if (validation.IsValid == false)
        {
            var errosMessages = validation.Errors
                .Select(f => f.ErrorMessage)
                .ToList();

            throw new ErrorOnValidationException(errosMessages);
        }
    }
}
