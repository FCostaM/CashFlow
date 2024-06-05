using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces.Repositories.Expenses;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class ExpenseRepository : IExpenseRepository
{
    public void AddExpense(Expense expense)
    {
        var dbContext = new CashFlowDbContext();

        dbContext.Add(expense);

        dbContext.SaveChanges();
    }
}
