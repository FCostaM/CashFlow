using AutoMapper;
using CashFlow.Application.Interfaces.Expenses;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Interfaces.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses;

/// <summary>
/// Use case for retrieving all expenses.
/// </summary>
public class GetAllExpensesUseCase : IGetAllExpensesUseCase
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
    /// Initializes a new instance of the <see cref="GetAllExpensesUseCase"/> class.
    /// </summary>
    /// <param name="repository">The repository for read-only operations on expenses.</param>
    /// <param name="mapper">The mapper for converting entities to response models.</param>
    public GetAllExpensesUseCase(IExpenseReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Executes the use case to retrieve all expenses.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing the response with the list of expenses.</returns>
    public async Task<GetExpensesResponse> Execute()
    {
        var result = await _repository.GetAllExpenses();

        return new GetExpensesResponse
        {
            Expenses = _mapper.Map<List<ShortExpenseResponse>>(result)
        };
    }
}
