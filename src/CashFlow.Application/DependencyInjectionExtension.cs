using CashFlow.Application.Interfaces;
using CashFlow.Application.UseCases.Expenses;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application;

public static class DependencyInjectionExtension
{
    public static void AddApllicationServices(this IServiceCollection services)
    {
        services.AddScoped<IExpenseRegisterUseCase, ExpenseRegisterUseCase>();
    }
}
