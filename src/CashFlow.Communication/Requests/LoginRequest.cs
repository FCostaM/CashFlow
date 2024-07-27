namespace CashFlow.Communication.Requests;

/// <summary>
/// Represents a request to login a user.
/// </summary>
public class LoginRequest
{
    /// <summary>
    /// Represents the user's e-mail address.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Represents the user's access password.
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
