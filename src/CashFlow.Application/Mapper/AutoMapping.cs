using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.Mapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<ExpenseRegisterRequest, Expense>();
    }

    private void EntityToResponse()
    {
        CreateMap<Expense, ExpenseRegisterResponse>();
        CreateMap<Expense, ShortExpenseResponse>();
        CreateMap<Expense, ExpenseResponse>();
    }
}
