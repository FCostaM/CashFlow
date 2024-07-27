using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses.Users;

namespace CashFlow.Application.Interfaces.Login;

/// <summary>
/// Defines the contract of a use case for handling user login.
/// </summary>
public interface ILoginUseCase
{
    /// <summary>
    /// Executes the use case to login a user.
    /// </summary>
    /// <param name="request">The request containing the user login information.</param>
    /// <returns>The response containing the logged-in user details.</returns>
    Task<UserRegisterResponse> Execute(LoginRequest request);
}
