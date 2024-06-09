using AutoMapper;
using CashFlow.Application.Interfaces;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Exception.CustomExceptions;
using CashFlow.Exception.Resources;

namespace CashFlow.Application.UseCases.Expenses;

public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
{
    private readonly IExpenseReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetExpenseByIdUseCase(IExpenseReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

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
