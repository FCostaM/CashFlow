using AutoMapper;
using CashFlow.Application.Interfaces;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses;

public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
{
    private readonly IExpenseRepository _repository;
    private readonly IMapper _mapper;

    public GetExpenseByIdUseCase(IExpenseRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ExpenseResponse> Execute(long id)
    {
        var result = await _repository.GetExpenseById(id);

        return _mapper.Map<ExpenseResponse>(result);
    }
}
