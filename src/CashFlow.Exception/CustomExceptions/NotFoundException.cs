using System.Net;

namespace CashFlow.Exception.CustomExceptions;

/// <summary>
/// Represents an exception thrown when an entity is not found.
/// </summary>
public class NotFoundException : CashFlowException
{
    /// <summary>
    /// Represents the status code associated with the exception.
    /// </summary>
    public override int StatusCode => (int) HttpStatusCode.NotFound;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public NotFoundException(string message) : base(message) { }

    /// <summary>
    /// Gets the list of error messages associated with the exception.
    /// </summary>
    /// <returns>A one-element list containing the error message.</returns>
    public override List<string> GetErrors()
    {
        return [Message];
    }
}
