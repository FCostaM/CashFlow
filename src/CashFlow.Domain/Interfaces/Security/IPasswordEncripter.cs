namespace CashFlow.Domain.Interfaces.Security;

/// <summary>
/// Provides an interface for password encryption.
/// </summary>
public interface IPasswordEncripter
{
    /// <summary>
    /// Encrypts the given password.
    /// </summary>
    /// <param name="password">The plain text password to encrypt.</param>
    /// <returns>The encrypted password.</returns>
    string Encrypy(string password);

    /// <summary>
    /// Verifies if the provided password matches the hashed password.
    /// </summary>
    /// <param name="password">The plain text password to verify.</param>
    /// <param name="hash">The hashed password to compare against.</param>
    /// <returns>True if the password matches the hash; otherwise, false.</returns>
    bool DoesPasswordMatch(string password, string hash);
}
