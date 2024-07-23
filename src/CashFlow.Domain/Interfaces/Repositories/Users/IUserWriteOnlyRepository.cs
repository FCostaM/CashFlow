using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces.Repositories.Users;

/// <summary>
/// Provides write-only operations for managing users.
/// </summary>
public interface IUserWriteOnlyRepository
{
    /// <summary>
    /// Adds a new user to the database.
    /// </summary>
    /// <param name="user">The user entity to be added to the database.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddUser(User user);
}
