using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces.Repositories.Expenses;

public interface IExpenseWriteOnlyRepository
{
    Task AddExpense(Expense expense);

    /// <summary>
    /// Delete an expense from database.
    /// Returns TRUE if the deletion was successful, otherwise returns FALSE.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteExpense(long id);

    void UpdateExpense(Expense expense);
}
