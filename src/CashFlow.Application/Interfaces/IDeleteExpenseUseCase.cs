namespace CashFlow.Application.Interfaces;

public interface IDeleteExpenseUseCase
{
    Task Execute(long id);
}
