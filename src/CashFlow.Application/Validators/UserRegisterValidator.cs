using CashFlow.Communication.Requests;
using CashFlow.Exception.Resources;
using FluentValidation;

namespace CashFlow.Application.Validators;

/// <summary>
/// Validator class for validating <see cref="UserRegisterRequest"/> objects.
/// </summary>
public class UserRegisterValidator : AbstractValidator<UserRegisterRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserRegisterValidator"/> class.
    /// Sets up validation rules for <see cref="UserRegisterRequest"/> properties.
    /// </summary>
    public UserRegisterValidator()
    {
        RuleFor(user => user.Name)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.EMPTY_NAME);

        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.EMPTY_EMAIL)
            .EmailAddress()
            .WithMessage(ErrorMessageResource.INVALID_EMAIL);

        RuleFor(user => user.Password)
            .SetValidator(new PasswordValidator<UserRegisterRequest>());
    }
}
