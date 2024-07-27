namespace CashFlow.Communication.Responses.Users;

/// <summary>
/// Represents the deafult response for a user.
/// </summary>
public class UserResponse
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
