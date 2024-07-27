using CashFlow.Application.Interfaces.Login;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses.Users;
using CashFlow.Domain.Interfaces.Repositories.Users;
using CashFlow.Domain.Interfaces.Security;
using CashFlow.Exception.CustomExceptions;

namespace CashFlow.Application.UseCases.Login;

/// <summary>
/// Use case for handling user login.
/// </summary>
public class LoginUseCase : ILoginUseCase
{
    /// <summary>
    /// Represents the repository for read-only operations on users.
    /// </summary>
    private readonly IUserReadOnlyRepository _repository;

    /// <summary>
    /// Represents the password encryption and verification service.
    /// </summary>
    private readonly IPasswordEncripter _passwordSecurity;

    /// <summary>
    /// Represents the token generator for generating JWT tokens.
    /// </summary>
    private readonly ITokenGenerator _tokenGenerator;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoginUseCase"/> class with the specified dependencies.
    /// </summary>
    /// <param name="repository">The user read-only repository.</param>
    /// <param name="security"></param>
    /// <param name="tokenGenerator">The token generator for creating JWT tokens.</param>
    public LoginUseCase(IUserReadOnlyRepository repository, IPasswordEncripter security, ITokenGenerator tokenGenerator)
    {
        _repository = repository;
        _passwordSecurity = security;
        _tokenGenerator = tokenGenerator;
    }

    /// <summary>
    /// Executes the use case to login a user.
    /// </summary>
    /// <param name="request">The request containing the user login information.</param>
    /// <returns>The response containing the logged-in user details.</returns>
    /// <exception cref="InvalidLoginException">Thrown when the login credentials are invalid or when the password does not match.</exception>
    public async Task<UserRegisterResponse> Execute(LoginRequest request)
    {
        var user = await _repository.GetUserByEmail(request.Email);

        if (user is null)
        {
            throw new InvalidLoginException();
        }

        var passwordMatch = _passwordSecurity.DoesPasswordMatch(request.Password, user.Password);

        if (passwordMatch is false)
        {
            throw new InvalidLoginException();
        }

        return new UserRegisterResponse
        {
            Name = user.Name,
            Token = _tokenGenerator.GenerateToken(user)
        };
    }
}
