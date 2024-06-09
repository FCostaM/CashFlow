using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class ExpenseRepository : IExpenseRepository
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

    public async Task<List<Expense>> GetAllExpenses()
    {
        return await _dbContext.Expenses.AsNoTracking().ToListAsync();
    }
}
