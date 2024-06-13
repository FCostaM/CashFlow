using System.Net;

namespace CashFlow.Exception.CustomExceptions;

/// <summary>
/// Represents an exception thrown when validation fails.
/// </summary>
public class ErrorOnValidationException : CashFlowException
{
    /// <summary>
    /// Represents a list of error messages associated with the exception.
    /// </summary>
    private readonly List<string> _errors;

    /// <summary>
    /// Represents the status code associated with the exception.
    /// </summary>
    public override int StatusCode => (int) HttpStatusCode.BadRequest;

    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorOnValidationException"/> class with a list of error messages.
    /// </summary>
    /// <param name="errorMessages">The list of error messages.</param>
    public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
    {
        _errors = errorMessages;
    }

    /// <summary>
    /// Gets the list of error messages associated with the exception.
    /// </summary>
    /// <returns>A list of error messages.</returns>
    public override List<string> GetErrors()
    {
        return _errors;
    }
}
