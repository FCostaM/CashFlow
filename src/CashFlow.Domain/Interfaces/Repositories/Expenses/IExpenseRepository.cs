using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces.Repositories.Expenses;

public interface IExpenseRepository
{
    void AddExpense(Expense expense);
}
