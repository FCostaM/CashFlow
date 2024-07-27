using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

/// <summary>
/// Repository for managing users in the database.
/// </summary>
internal class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    /// <summary>
    /// Represents the database context used for accessing the users data.
    /// </summary>
    private readonly CashFlowDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class using the specified database context.
    /// </summary>
    /// <param name="context">The database context to be used by this repository.</param>
    public UserRepository(CashFlowDbContext context)
    {
        _dbContext = context;
    }

    /// <summary>
    /// Adds a new user to the database.
    /// </summary>
    /// <param name="user">The user entity to be added to the database.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task AddUser(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    /// <summary>
    /// Checks if there is an active user with the specified email.
    /// </summary>
    /// <param name="email">The email to check for an active user.</param>
    /// <returns>A task that represents the asynchronous operation, 
    /// containing true if an active user with the specified email exists; otherwise, false.</returns>
    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(u => u.Email.Equals(email));
    }

    /// <summary>
    /// Retrieves a user by their email.
    /// </summary>
    /// <param name="email">The email of the user to be retrieved.</param>
    /// <returns>
    /// A task that represents the asynchronous operation, containing the user entity if found; otherwise, null.
    /// </returns>
    public async Task<User?> GetUserByEmail(string email)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email.Equals(email));
    }
}
