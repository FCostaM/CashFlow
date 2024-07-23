using CashFlow.Domain.Interfaces.Security;
using BC = BCrypt.Net.BCrypt;

namespace CashFlow.Infrastructure.Security;

/// <summary>
/// Provides methods for encrypting passwords using BCrypt.
/// </summary>
internal class PasswordEncripter : IPasswordEncripter
{
    /// <summary>
    /// Encrypts the given password using BCrypt.
    /// </summary>
    /// <param name="password">The plain text password to encrypt.</param>
    /// <returns>The encrypted password.</returns>
    public string Encrypy(string password)
    {
        return BC.HashPassword(password);
    }
}
