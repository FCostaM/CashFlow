namespace CashFlow.Communication.Responses;

/// <summary>
/// Represents an error response containing a list of error messages.
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// Represents a list of error messages.
    /// </summary>
    public List<string> ErrorMessages { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorResponse"/> class with a single error message.
    /// </summary>
    /// <param name="errorMessage">The error message.</param>
    public ErrorResponse(string errorMessage)
    {
        ErrorMessages = [errorMessage];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorResponse"/> class with a list of error messages.
    /// </summary>
    /// <param name="errorMessages">The list of error messages.</param>
    public ErrorResponse(List<string> errorMessage)
    {
        ErrorMessages = errorMessage;
    }
}
