namespace CashFlow.Domain.Interfaces;

public interface IUnitOfWork
{
    Task Commit();
}
