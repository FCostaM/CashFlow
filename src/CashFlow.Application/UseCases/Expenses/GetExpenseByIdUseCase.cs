using AutoMapper;
using CashFlow.Application.Interfaces.Expenses;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Exception.CustomExceptions;
using CashFlow.Exception.Resources;

namespace CashFlow.Application.UseCases.Expenses;

/// <summary>
/// Use case for retrieving an expense by its ID.
/// </summary>
public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
{
    /// <summary>
    /// Represents the repository for read-only operations on expenses.
    /// </summary>
    private readonly IExpenseReadOnlyRepository _repository;

    /// <summary>
    /// Represents the mapper for converting entities to response models.
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetExpenseByIdUseCase"/> class.
    /// </summary>
    /// <param name="repository">The repository for read-only operations on expenses.</param>
    /// <param name="mapper">The mapper for converting entities to response models.</param>
    public GetExpenseByIdUseCase(IExpenseReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Executes the use case to retrieve an expense by its ID.
    /// </summary>
    /// <param name="id">The ID of the expense to be retrieved.</param>
    /// <returns>A task that represents the asynchronous operation, containing the expense response if found.</returns>
    /// <exception cref="NotFoundException">Thrown when the expense is not found.</exception>
    public async Task<ExpenseResponse> Execute(long id)
    {
        var result = await _repository.GetExpenseById(id);

        if (result is null)
        {
            throw new NotFoundException(ErrorMessageResource.EXPENSE_NOT_FOUND);
        }

        return _mapper.Map<ExpenseResponse>(result);
    }
}
