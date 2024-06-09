using CashFlow.Application.Interfaces;
using CashFlow.Domain.Interfaces;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Exception.CustomExceptions;
using CashFlow.Exception.Resources;

namespace CashFlow.Application.UseCases.Expenses;

public class DeleteExpenseUseCase : IDeleteExpenseUseCase
{
    private readonly IExpenseWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteExpenseUseCase(IExpenseWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

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
