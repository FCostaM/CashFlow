namespace CashFlow.Communication.Responses;

public class ErrorResponse
{
    public string ErrorMessage { get; set; } = string.Empty;

    public ErrorResponse(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}
