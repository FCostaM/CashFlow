using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class ExpenseRepository : IExpenseWriteOnlyRepository, IExpenseReadOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;

    public ExpenseRepository(CashFlowDbContext context)
    {
        _dbContext = context;
    }

    public async Task AddExpense(Expense expense)
    {
        await _dbContext.Expenses.AddAsync(expense);
    }

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

    public async Task<List<Expense>> GetAllExpenses()
    {
        return await _dbContext.Expenses.AsNoTracking().ToListAsync();
    }

    public async Task<Expense?> GetExpenseById(long id)
    {
        return await _dbContext.Expenses
            .AsNoTracking()
            .FirstOrDefaultAsync(expense => expense.Id == id);
    }

    public async Task<Expense?> GetExpenseForUpdate(long id)
    {
        return await _dbContext.Expenses
            .FirstOrDefaultAsync(expense => expense.Id == id);
    }

    public void UpdateExpense(Expense expense)
    {
        _dbContext.Expenses.Update(expense);
    }
}
