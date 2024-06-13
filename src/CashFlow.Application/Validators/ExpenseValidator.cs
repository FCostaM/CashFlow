using CashFlow.Communication.Requests;
using CashFlow.Exception.Resources;
using FluentValidation;

namespace CashFlow.Application.Validators;

/// <summary>
/// Validator class for validating <see cref="ExpenseRequest"/> objects.
/// </summary>
public class ExpenseValidator : AbstractValidator<ExpenseRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExpenseValidator"/> class.
    /// Sets up validation rules for <see cref="ExpenseRequest"/> properties.
    /// </summary>
    public ExpenseValidator()
    {
        RuleFor(expense => expense.Title)
            .NotEmpty()
            .WithMessage(ErrorMessageResource.TITLE_REQUIRED);

        RuleFor(expense => expense.Date)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage(ErrorMessageResource.PAST_DATE_EXPENSE);

        RuleFor(expense => expense.Amount)
            .GreaterThan(0)
            .WithMessage(ErrorMessageResource.AMOUNT_UNDER_ZERO);

        RuleFor(expense => expense.PaymentType)
            .IsInEnum()
            .WithMessage(ErrorMessageResource.PAYMENT_TYPE_INVALID);
    }
}
