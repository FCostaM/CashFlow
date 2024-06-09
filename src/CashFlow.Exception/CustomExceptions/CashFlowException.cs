namespace CashFlow.Exception.CustomExceptions;

public abstract class CashFlowException : SystemException
{
    public abstract int StatusCode { get; }

    protected CashFlowException(string? message) : base(message)
    {
    }

    public abstract List<string> GetErrors();
}
