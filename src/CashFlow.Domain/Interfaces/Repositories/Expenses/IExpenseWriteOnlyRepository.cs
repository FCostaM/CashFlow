using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces.Repositories.Expenses;

public interface IExpenseWriteOnlyRepository
{
    Task AddExpense(Expense expense);    
}
