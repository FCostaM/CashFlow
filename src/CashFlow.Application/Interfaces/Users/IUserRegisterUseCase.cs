using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses.Users;

namespace CashFlow.Application.Interfaces.Users;

/// <summary>
/// Defines the contract for a use case to register a new user.
/// </summary>
public interface IUserRegisterUseCase
{
    /// <summary>
    /// Executes the use case to register a new user.
    /// </summary>
    /// <param name="request">The request containing the user information.</param>
    /// <returns>The response containing the registered user details.</returns>
    public Task<UserRegisterResponse> Execute(UserRegisterRequest request);
}
