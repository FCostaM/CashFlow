namespace CashFlow.Communication.Requests;

/// <summary>
/// Represents a request to create a user.
/// </summary>
public class UserRegisterRequest
{
    /// <summary>
    /// Represents the user's full name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Represents the user's e-mail address.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Represents the user's access password.
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
