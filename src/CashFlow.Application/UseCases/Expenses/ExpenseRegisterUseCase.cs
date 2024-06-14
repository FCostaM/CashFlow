using AutoMapper;
using CashFlow.Application.Interfaces.Expenses;
using CashFlow.Application.Validators;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Exception.CustomExceptions;

namespace CashFlow.Application.UseCases.Expenses;

/// <summary>
/// Use case for registering a new expense.
/// </summary>
public class ExpenseRegisterUseCase : IExpenseRegisterUseCase
{
    /// <summary>
    /// Represents the repository for write-only operations on expenses.
    /// </summary>
    private readonly IExpenseWriteOnlyRepository _repository;

    /// <summary>
    /// Represents the unit of work for committing transactions.
    /// </summary>
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Represents the mapper for converting between request/response models and entities.
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpenseRegisterUseCase"/> class.
    /// </summary>
    /// <param name="repository">The repository for write-only operations on expenses.</param>
    /// <param name="unitOfWork">The unit of work for committing transactions.</param>
    /// <param name="mapper">The mapper for converting between request/response models and entities.</param>
    public ExpenseRegisterUseCase(IExpenseWriteOnlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <summary>
    /// Executes the use case to register a new expense.
    /// </summary>
    /// <param name="request">The request containing the expense details.</param>
    /// <returns>The response containing the registered expense details.</returns>
    public async Task<ExpenseRegisterResponse> Execute(ExpenseRequest request)
    {
        Validate(request);

        var entity = _mapper.Map<Expense>(request);

        await _repository.AddExpense(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ExpenseRegisterResponse>(entity);
    }

    /// <summary>
    /// Validates the expense request.
    /// </summary>
    /// <param name="request">The request to validate.</param>
    /// <exception cref="ErrorOnValidationException">Thrown when validation fails.</exception>
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
