using CashFlow.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure.Migrations;

/// <summary>
/// Provides methods for performing database migrations.
/// </summary>
public static class DataBaseMigration
{
    /// <summary>
    /// Migrates the database to the latest version using the provided service provider.
    /// </summary>
    /// <param name="serviceProvider">The service provider used to resolve the database context.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async static Task MigrateDatabase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<CashFlowDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}
