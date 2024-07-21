namespace CashFlow.Domain.Enums;

/// <summary>
/// Represents the entity that contains a user's permission level contents within the application.
/// </summary>
public static class Roles
{
    /// <summary>
    /// Represents an administrator permission level on the application.
    /// </summary>
    public const string ADMIN = "administrador";

    /// <summary>
    /// Represents a team member permission level on the application.
    /// </summary>
    public const string TEAM_MEMBER = "teamMember";
}
