using AutoMapper;
using CashFlow.Application.Interfaces;
using CashFlow.Application.Validators;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Interfaces;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Exception.CustomExceptions;
using CashFlow.Exception.Resources;

namespace CashFlow.Application.UseCases.Expenses;

public class UpdateExpenseUseCase : IUpdateExpenseUseCase
{
    private readonly IExpenseWriteOnlyRepository _writeRepository;
    private readonly IExpenseReadOnlyRepository _readRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateExpenseUseCase(
        IExpenseWriteOnlyRepository writeRepositor,
        IExpenseReadOnlyRepository readRepositor,
        IMapper mapper, IUnitOfWork unitOfWork)
    {
        _writeRepository = writeRepositor;
        _readRepository = readRepositor;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id, ExpenseRequest request)
    {
        Validate(request);

        var expense = await _readRepository.GetExpenseForUpdate(id);

        if (expense is null)
        {
            throw new NotFoundException(ErrorMessageResource.EXPENSE_NOT_FOUND);
        }

        _mapper.Map(request, expense);

        _writeRepository.UpdateExpense(expense);

        await _unitOfWork.Commit();
    }

    private void Validate(ExpenseRequest request)
    {
        var validation = new ExpenseValidator().Validate(request);

        if (validation.IsValid == false)
        {
            var errosMessages = validation.Errors
                .Select(f => f.ErrorMessage)
                .ToList();

            throw new ErrorOnValidationException(errosMessages);
        }
    }
}
