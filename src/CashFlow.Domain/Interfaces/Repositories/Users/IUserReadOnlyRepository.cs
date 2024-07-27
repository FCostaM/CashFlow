using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces.Repositories.Users;

/// <summary>
/// Provides read-only operations for managing users.
/// </summary>
public interface IUserReadOnlyRepository
{
    /// <summary>
    /// Checks if there is an active user with the specified email.
    /// </summary>
    /// <param name="email">The email to check for an active user.</param>
    /// <returns>A task that represents the asynchronous operation, 
    /// containing true if an active user with the specified email exists; otherwise, false.</returns>
    Task<bool> ExistActiveUserWithEmail(string email);

    /// <summary>
    /// Retrieves a user by their email.
    /// </summary>
    /// <param name="email">The email of the user to be retrieved.</param>
    /// <returns>
    /// A task that represents the asynchronous operation, containing the user entity if found; otherwise, null.
    /// </returns>
    Task<User?> GetUserByEmail(string email);
}
