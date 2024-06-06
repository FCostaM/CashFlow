using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        AddDbContext(services);
        AddRepositories(services);
    }

    private static void AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<CashFlowDbContext>();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
    }
}
