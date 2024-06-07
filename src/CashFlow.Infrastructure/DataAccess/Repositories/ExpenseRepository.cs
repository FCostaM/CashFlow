using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces.Repositories.Expenses;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class ExpenseRepository : IExpenseRepository
{
    private readonly CashFlowDbContext _dbContext;

    public ExpenseRepository(CashFlowDbContext context)
    {
        _dbContext = context;
    }

    public void AddExpense(Expense expense)
    {
        _dbContext.Expenses.Add(expense);
    }
}
