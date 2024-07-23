using CashFlow.Exception.Resources;
using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace CashFlow.Application.Validators;

/// <summary>
/// Validator for password properties.
/// </summary>
/// <typeparam name="T">The type of the object being validated.</typeparam>
public partial class PasswordValidator<T> : PropertyValidator<T, string>
{
    /// <summary>
    /// Gets the name of the validator.
    /// </summary>
    public override string Name => "PasswordValidator";

    /// <summary>
    /// Key for error message.
    /// </summary>
    private const string ERROR_MESSAGE_KEY = "ErrorMessage";

    /// <summary>
    /// Provides the default message template for the validator.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <returns>The default message template.</returns>
    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return $"{{{ERROR_MESSAGE_KEY}}}";
    }

    /// <summary>
    /// Determines whether the specified password is valid.
    /// </summary>
    /// <param name="context">The validation context.</param>
    /// <param name="password">The password to validate.</param>
    /// <returns>Returns true if the password is valid; otherwise, false.</returns>
    public override bool IsValid(ValidationContext<T> context, string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ErrorMessageResource.EMPTY_PASSWORD);
            return false;
        }

        if (password.Length < 8)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ErrorMessageResource.PASSWORD_LENGTH_UNDER_8);
            return false;
        }

        if (UpperCaseLetter().IsMatch(password) == false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ErrorMessageResource.PASSWORD_WITHOUT_UPPERCASE_LETTER);
            return false;
        }

        if (LowerCaseLetter().IsMatch(password) == false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ErrorMessageResource.PASSWORD_WITHOUT_LOWERCASE_LETTER);
            return false;
        }

        if (Numbers().IsMatch(password) == false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ErrorMessageResource.PASSWORD_WITHOUT_NUMBER);
            return false;
        }

        if (SpecialCharacter().IsMatch(password) == false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ErrorMessageResource.PASSWORD_WITHOUT_SPECIAL_CHARACTER);
            return false;
        }

        return true;
    }

    [GeneratedRegex(@"[A-Z]+")]
    private static partial Regex UpperCaseLetter();

    [GeneratedRegex(@"[a-z]+")]
    private static partial Regex LowerCaseLetter();

    [GeneratedRegex(@"[0-9]+")]
    private static partial Regex Numbers();

    [GeneratedRegex(@"[\!\?\*\.\-]+")]
    private static partial Regex SpecialCharacter();
}
