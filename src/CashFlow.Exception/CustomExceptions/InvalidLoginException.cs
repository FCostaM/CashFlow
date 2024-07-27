using CashFlow.Exception.Resources;
using System.Net;

namespace CashFlow.Exception.CustomExceptions;

/// <summary>
/// Represents an exception thrown when an invalid login attempt is made.
/// </summary>
public class InvalidLoginException : CashFlowException
{
    /// <summary>
    /// Represents the status code associated with the exception.
    /// </summary>
    public override int StatusCode => (int) HttpStatusCode.Unauthorized;

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidLoginException"/> with a <see cref="ErrorMessageResource.INVALID_LOGIN"/> message.
    /// </summary>
    public InvalidLoginException() : base(ErrorMessageResource.INVALID_LOGIN)
    {
    }

    /// <summary>
    /// Gets the list of error messages associated with the exception.
    /// </summary>
    /// <returns>A one-element list containing the error message.</returns>
    public override List<string> GetErrors()
    {
        return [Message];
    }
}
