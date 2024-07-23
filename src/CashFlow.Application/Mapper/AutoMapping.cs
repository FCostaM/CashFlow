using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses.Expenses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.Mapper;

/// <summary>
/// Profile for AutoMapper configurations in the application.
/// </summary>
public class AutoMapping : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AutoMapping"/> class and sets up the mappings.
    /// </summary>
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    /// <summary>
    /// Configures the mapping from request models to entity models.
    /// </summary>
    private void RequestToEntity()
    {
        // User
        CreateMap<UserRegisterRequest, User>()
            .ForMember(dest => dest.Password, config => config.Ignore());

        //Expense
        CreateMap<ExpenseRequest, Expense>();
    }

    /// <summary>
    /// Configures the mapping from entity models to response models.
    /// </summary>
    private void EntityToResponse()
    {
        CreateMap<Expense, ExpenseRegisterResponse>();
        CreateMap<Expense, ShortExpenseResponse>();
        CreateMap<Expense, ExpenseResponse>();
    }
}
