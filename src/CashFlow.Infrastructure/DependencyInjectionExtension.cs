using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
    }
}
