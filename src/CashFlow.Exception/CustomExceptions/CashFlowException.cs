namespace CashFlow.Exception.CustomExceptions;

/// <summary>
/// Represents a base exception class for application exceptions.
/// </summary>
public abstract class CashFlowException : SystemException
{
    /// <summary>
    /// Represents the status code associated with the exception.
    /// </summary>
    public abstract int StatusCode { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CashFlowException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    protected CashFlowException(string? message) : base(message) { }

    /// <summary>
    /// Gets the list of error messages associated with the exception.
    /// </summary>
    /// <returns>A list of error messages.</returns>
    public abstract List<string> GetErrors();
}
