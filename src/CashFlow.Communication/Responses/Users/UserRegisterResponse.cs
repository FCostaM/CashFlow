namespace CashFlow.Communication.Responses.Users;

/// <summary>
/// Represents the response after registering a new user.
/// </summary>
public class UserRegisterResponse
{
    /// <summary>
    /// Represents the user's full name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Represents the authentication token assigned to the user.
    /// </summary>
    public string Token { get; set; } = string.Empty;
}
