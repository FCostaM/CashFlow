using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces.Security;

/// <summary>
/// Provides an interface for generating JWT tokens.
/// </summary>
public interface ITokenGenerator
{
    /// <summary>
    /// Generates a JWT token for the specified user.
    /// </summary>
    /// <param name="user">The user for whom the token is being generated.</param>
    /// <returns>A JWT token as a string.</returns>
    string GenerateToken(User user);
}
