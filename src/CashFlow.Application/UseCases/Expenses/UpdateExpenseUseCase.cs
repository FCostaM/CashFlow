using AutoMapper;
using CashFlow.Application.Interfaces;
using CashFlow.Application.Validators;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Interfaces;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Exception.CustomExceptions;
using CashFlow.Exception.Resources;

namespace CashFlow.Application.UseCases.Expenses;

/// <summary>
/// Use case for updating an existing expense.
/// </summary>
public class UpdateExpenseUseCase : IUpdateExpenseUseCase
{
    /// <summary>
    /// Represents the repository for write-only operations on expenses.
    /// </summary>
    private readonly IExpenseWriteOnlyRepository _writeRepository;

    /// <summary>
    /// Represents the repository for read-only operations on expenses.
    /// </summary>
    private readonly IExpenseReadOnlyRepository _readRepository;

    /// <summary>
    /// Represents the mapper for converting request models to entities and vice versa.
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Represents the unit of work to manage transaction scope.
    /// </summary>
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateExpenseUseCase"/> class.
    /// </summary>
    /// <param name="writeRepository">The repository for write-only operations on expenses.</param>
    /// <param name="readRepository">The repository for read-only operations on expenses.</param>
    /// <param name="mapper">The mapper for converting request models to entities and vice versa.</param>
    /// <param name="unitOfWork">The unit of work to manage transaction scope.</param>
    public UpdateExpenseUseCase(IExpenseWriteOnlyRepository writeRepositor, IExpenseReadOnlyRepository readRepositor, 
        IMapper mapper, IUnitOfWork unitOfWork)
    {
        _writeRepository = writeRepositor;
        _readRepository = readRepositor;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Executes the use case to update an existing expense.
    /// </summary>
    /// <param name="id">The ID of the expense to be updated.</param>
    /// <param name="request">The request containing updated expense details.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="NotFoundException">Thrown when the expense is not found.</exception>
    public async Task Execute(long id, ExpenseRequest request)
    {
        Validate(request);

        var expense = await _readRepository.GetExpenseForUpdate(id);

        if (expense is null)
        {
            throw new NotFoundException(ErrorMessageResource.EXPENSE_NOT_FOUND);
        }

        _mapper.Map(request, expense);

        _writeRepository.UpdateExpense(expense);

        await _unitOfWork.Commit();
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
