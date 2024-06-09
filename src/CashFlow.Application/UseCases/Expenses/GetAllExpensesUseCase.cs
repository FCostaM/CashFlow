using AutoMapper;
using CashFlow.Application.Interfaces;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Interfaces.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses;

public class GetAllExpensesUseCase : IGetAllExpensesUseCase
{
    private readonly IExpenseReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetAllExpensesUseCase(IExpenseReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetExpensesResponse> Execute()
    {
        var result = await _repository.GetAllExpenses();

        return new GetExpensesResponse
        {
            Expenses = _mapper.Map<List<ShortExpenseResponse>>(result)
        };
    }
}
