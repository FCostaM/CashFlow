using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

/// <summary>
/// Repository for managing expenses in the database.
/// </summary>
internal class ExpenseRepository : IExpenseWriteOnlyRepository, IExpenseReadOnlyRepository
{
    /// <summary>
    /// Represents the database context used for accessing the expenses data.
    /// </summary>
    private readonly CashFlowDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpenseRepository"/> class using the specified database context.
    /// </summary>
    /// <param name="context">The database context to be used by this repository.</param>
    public ExpenseRepository(CashFlowDbContext context)
    {
        _dbContext = context;
    }

    /// <summary>
    /// Adds a new expense to the database.
    /// </summary>
    /// <param name="expense">The expense entity to be added.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task AddExpense(Expense expense)
    {
        await _dbContext.Expenses.AddAsync(expense);
    }

    /// <summary>
    /// Deletes an expense from the database based on its ID.
    /// </summary>
    /// <param name="id">The ID of the expense to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation, containing true if the expense was found and deleted; otherwise, false.</returns>
    public async Task<bool> DeleteExpense(long id)
    {
        var result = await _dbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == id);

        if (result is null)
        {
            return false;
        }
        else
        {
            _dbContext.Expenses.Remove(result);
            return true;
        }
    }

    /// <summary>
    /// Retrieves all expenses from the database.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing a list of all expenses.</returns>
    public async Task<List<Expense>> GetAllExpenses()
    {
        return await _dbContext.Expenses.AsNoTracking().ToListAsync();
    }

    /// <summary>
    /// Retrieves an expense by its ID without tracking the entity.
    /// </summary>
    /// <param name="id">The ID of the expense to be retrieved.</param>
    /// <returns>A task that represents the asynchronous operation, containing the expense if found; otherwise, null.</returns>
    public async Task<Expense?> GetExpenseById(long id)
    {
        return await _dbContext.Expenses
            .AsNoTracking()
            .FirstOrDefaultAsync(expense => expense.Id == id);
    }

    /// <summary>
    /// Retrieves an expense by its ID for update purposes, with tracking enabled.
    /// </summary>
    /// <param name="id">The ID of the expense to be retrieved for update.</param>
    /// <returns>A task that represents the asynchronous operation, containing the expense if found; otherwise, null.</returns>
    public async Task<Expense?> GetExpenseForUpdate(long id)
    {
        return await _dbContext.Expenses
            .FirstOrDefaultAsync(expense => expense.Id == id);
    }

    /// <summary>
    /// Retrieves a list of expenses filtered by a date range.
    /// </summary>
    /// <param name="startDate">The start date of the filter range.</param>
    /// <param name="endDate">The end date of the filter range.</param>
    /// <returns>A task that represents the asynchronous operation, containing a list of expenses that fall within the specified date range.</returns>
    public async Task<List<Expense>> FilterExpenseByDate(DateTime startDate, DateTime endDate)
    {
        return await _dbContext.Expenses
            .AsNoTracking()
            .Where(expense => expense.Date >= startDate && expense.Date <= endDate)
            .OrderBy(expense => expense.Date)
            .ThenBy(expense => expense.Title)
            .ToListAsync();
    }
    
    /// <summary>
    /// Updates an existing expense in the database.
    /// </summary>
    /// <param name="expense">The expense entity with updated values.</param>
    public void UpdateExpense(Expense expense)
    {
        _dbContext.Expenses.Update(expense);
    }
}
