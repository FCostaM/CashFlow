using CashFlow.Domain.Interfaces;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Domain.Interfaces.Repositories.Users;
using CashFlow.Domain.Interfaces.Security;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using CashFlow.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;

/// <summary>
/// Extension methods for setting up infrastructure services in the DI container.
/// </summary>
public static class DependencyInjectionExtension
{
    /// <summary>
    /// Adds infrastructure services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> from which to retrieve configuration data.</param>
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
        AddSecurity(services, configuration);
    }

    /// <summary>
    /// Adds the database context to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> from which to retrieve the connection string.</param>
    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MySQLConnection");

        var serverVersion = new MySqlServerVersion(new Version(8, 0, 37));

        services.AddDbContext<CashFlowDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }

    /// <summary>
    /// Adds repositories to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    private static void AddRepositories(this IServiceCollection services)
    {
        //Unit of work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //User
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();

        //Expense
        services.AddScoped<IExpenseReadOnlyRepository, ExpenseRepository>();
        services.AddScoped<IExpenseWriteOnlyRepository, ExpenseRepository>();
    }

    /// <summary>
    /// Adds security services to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> from which to retrieve the connection string.</param>
    private static void AddSecurity(this IServiceCollection services, IConfiguration configuration)
    {
        //Password encriptor
        services.AddScoped<IPasswordSecurity, PasswordSecurity>();

        //Access token
        var expiresAt = configuration.GetValue<uint>("Settings:JWT:ExpiresAt");
        var key = configuration.GetValue<string>("Settings:JWT:SigningKey");

        services.AddScoped<ITokenGenerator>(config => new JwtTokenGenerator(expiresAt, key!));
    }
}
