namespace CashFlow.Domain.Entities;

/// <summary>
/// Represents an user entity.
/// </summary>
public class User
{
    /// <summary>
    /// Represents a unique identifier for a user.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Represents a user's full name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Represents a user's email address.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Represents a user's password to access the application.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Represents a user's unique identifier used for token generation.
    /// </summary>
    public Guid UserIdentifier { get; set; }

    /// <summary>
    /// Represents a user's permission level within the application.
    /// </summary>
    public string Role { get; set; } = string.Empty;
}
