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
}
