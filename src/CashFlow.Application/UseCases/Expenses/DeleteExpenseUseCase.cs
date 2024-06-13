using CashFlow.Application.Interfaces;
using CashFlow.Domain.Interfaces;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Exception.CustomExceptions;
using CashFlow.Exception.Resources;

namespace CashFlow.Application.UseCases.Expenses;

/// <summary>
/// Use case for deleting an expense.
/// </summary>
public class DeleteExpenseUseCase : IDeleteExpenseUseCase
{
    /// <summary>
    /// Represents the repository for write-only operations on expenses.
    /// </summary>
    private readonly IExpenseWriteOnlyRepository _repository;

    /// <summary>
    /// Represents the unit of work for committing transactions.
    /// </summary>
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteExpenseUseCase"/> class.
    /// </summary>
    /// <param name="repository">The repository for write-only operations on expenses.</param>
    /// <param name="unitOfWork">The unit of work for committing transactions.</param>
    public DeleteExpenseUseCase(IExpenseWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Executes the use case to delete an expense by its ID.
    /// </summary>
    /// <param name="id">The ID of the expense to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="NotFoundException">Thrown when the expense with the specified ID is not found.</exception>
    public async Task Execute(long id)
    {
        var result = await _repository.DeleteExpense(id);

        if (result is false)
        {
            throw new NotFoundException(ErrorMessageResource.EXPENSE_NOT_FOUND);
        }

        await _unitOfWork.Commit();
    }
}
