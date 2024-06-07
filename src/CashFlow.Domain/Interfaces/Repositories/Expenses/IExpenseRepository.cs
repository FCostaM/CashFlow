using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces.Repositories.Expenses;

public interface IExpenseRepository
{
    Task AddExpense(Expense expense);
}
