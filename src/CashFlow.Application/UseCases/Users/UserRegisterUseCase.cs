using AutoMapper;
using CashFlow.Application.Interfaces.Users;
using CashFlow.Application.Validators;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses.Users;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Interfaces;
using CashFlow.Domain.Interfaces.Repositories.Users;
using CashFlow.Domain.Interfaces.Security;
using CashFlow.Exception.CustomExceptions;
using CashFlow.Exception.Resources;
using FluentValidation.Results;

namespace CashFlow.Application.UseCases.Users;

/// <summary>
/// Use case for registering a new user.
/// </summary>
public class UserRegisterUseCase : IUserRegisterUseCase
{
    /// <summary>
    /// Represents the password encryptor.
    /// </summary>
    private readonly IPasswordEncripter _encripter;

    /// <summary>
    /// Represents the repository for read-only operations on users.
    /// </summary>
    private readonly IUserReadOnlyRepository _readRepository;

    /// <summary>
    /// Represents the repository for write-only operations on users.
    /// </summary>
    private readonly IUserWriteOnlyRepository _writeRepository;

    /// <summary>
    /// Represents the mapper for converting between request/response models and entities.
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Represents the unit of work for committing transactions.
    /// </summary>
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Represents the token generator for generating JWT tokens.
    /// </summary>
    private readonly ITokenGenerator _tokenGenerator;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRegisterUseCase"/> class with the specified dependencies.
    /// </summary>
    /// <param name="encripter">The password encripter.</param>
    /// <param name="readRepository">The user read-only repository.</param>
    /// <param name="writeRepository">The user write-only repository.</param>
    /// <param name="mapper">The mapper for converting request models to entities and vice versa.</param>
    /// <param name="unitOfWork">The unit of work to manage transaction scope.</param>
    /// <param name="tokenGenerator">The token generator for creating JWT tokens.</param>
    public UserRegisterUseCase(IPasswordEncripter encripter, IUserReadOnlyRepository readRepository, IUserWriteOnlyRepository writeRepository, 
        IMapper mapper, IUnitOfWork unitOfWork, ITokenGenerator tokenGenerator)
    {
        _encripter = encripter;
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _tokenGenerator = tokenGenerator;
    }

    /// <summary>
    /// Executes the use case to register a new user.
    /// </summary>
    /// <param name="request">The request containing the user information.</param>
    /// <returns>The response containing the registered user details.</returns>
    public async Task<UserResponse> Execute(UserRegisterRequest request)
    {
        await Validate(request);

        var user = _mapper.Map<User>(request);
        user.Password = _encripter.Encrypy(request.Password);
        user.UserIdentifier = Guid.NewGuid();
        user.Role = Roles.TEAM_MEMBER;

        await _writeRepository.AddUser(user);

        await _unitOfWork.Commit();

        return new UserResponse
        {
            Name = user.Name,
            Token = _tokenGenerator.GenerateToken(user)
        };
    }

    /// <summary>
    /// Validates the user request.
    /// </summary>
    /// <param name="request">The user register request to be validated.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ErrorOnValidationException">Thrown when validation fails.</exception>
    private async Task Validate(UserRegisterRequest request)
    {
        var result = new UserRegisterValidator().Validate(request);

        var emailExist = await _readRepository.ExistActiveUserWithEmail(request.Email);

        if (emailExist)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ErrorMessageResource.EMAIL_ALREADY_REGISTERED));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors
                .Select(f => f.ErrorMessage)
                .ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
