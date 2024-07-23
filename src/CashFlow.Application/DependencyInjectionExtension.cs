using CashFlow.Application.Interfaces.Expenses;
using CashFlow.Application.Interfaces.Reports;
using CashFlow.Application.Interfaces.Users;
using CashFlow.Application.Mapper;
using CashFlow.Application.UseCases.Expenses;
using CashFlow.Application.UseCases.Reports;
using CashFlow.Application.UseCases.Users;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application;

/// <summary>
/// Extension methods for setting up apllication services in the DI container.
/// </summary>
public static class DependencyInjectionExtension
{
    /// <summary>
    /// Adds application services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    public static void AddApllicationServices(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    /// <summary>
    /// Adds automapper to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    /// <summary>
    /// Adds use cases to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    private static void AddUseCases(IServiceCollection services)
    {
        //Users
        services.AddScoped<IUserRegisterUseCase, UserRegisterUseCase>();

        // Expenses
        services.AddScoped<IExpenseRegisterUseCase, ExpenseRegisterUseCase>();
        services.AddScoped<IGetAllExpensesUseCase, GetAllExpensesUseCase>();
        services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
        services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();
        services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();

        // Reports
        services.AddScoped<IGenerateExpensesReportExcelUseCase, GenerateExpensesReportExcelUseCase>();
        services.AddScoped<IGenerateExpensesReportPdfUseCase, GenerateExpensesReportPdfUseCase>();
    }    
}
