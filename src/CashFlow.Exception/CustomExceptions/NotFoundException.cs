namespace CashFlow.Exception.CustomExceptions;

public class NotFoundException : CashFlowException
{
    public NotFoundException(string message) : base(message)
    {
    }
}
