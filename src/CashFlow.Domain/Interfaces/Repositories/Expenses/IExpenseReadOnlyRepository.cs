using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces.Repositories.Expenses;

public interface IExpenseReadOnlyRepository
{
    Task<List<Expense>> GetAllExpenses();
    Task<Expense?> GetExpenseById(long id);
}
