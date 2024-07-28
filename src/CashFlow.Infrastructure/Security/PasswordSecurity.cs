using CashFlow.Domain.Interfaces.Security;
using BC = BCrypt.Net.BCrypt;

namespace CashFlow.Infrastructure.Security;

/// <summary>
/// Provides methods for encrypting passwords using BCrypt.
/// </summary>
internal class PasswordSecurity : IPasswordSecurity
{
    /// <summary>
    /// Encrypts the given password using BCrypt.
    /// </summary>
    /// <param name="password">The plain text password to encrypt.</param>
    /// <returns>The encrypted password.</returns>
    public string EncrypytPassword(string password)
    {
        return BC.HashPassword(password);
    }

    /// <summary>
    /// Verifies if the provided password matches the hashed password.
    /// </summary>
    /// <param name="password">The plain text password to verify.</param>
    /// <param name="hash">The hashed password to compare against.</param>
    /// <returns>True if the password matches the hash; otherwise, false.</returns>
    public bool DoesPasswordMatch(string password, string hash)
    {
        return BC.Verify(password, hash);
    }
}
