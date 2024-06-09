namespace CashFlow.Exception.CustomExceptions;

public abstract class CashFlowException : SystemException
{
    protected CashFlowException(string? message) : base(message)
    {
    }
}
