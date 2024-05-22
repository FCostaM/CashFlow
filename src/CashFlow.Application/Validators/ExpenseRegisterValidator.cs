using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.Validators;

public class ExpenseRegisterValidator : AbstractValidator<ExpenseRegisterRequest>
{
    public ExpenseRegisterValidator()
    {
        RuleFor(expense => expense.Title)
            .NotEmpty()
            .WithMessage("Title is required");
        RuleFor(expense => expense.Date)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Expense cannot be for the future");
        RuleFor(expense => expense.Amount)
            .GreaterThan(0)
            .WithMessage("Amount must be greater then zero");
        RuleFor(expense => expense.PaymentType)
            .IsInEnum()
            .WithMessage("Payment type is invalid");
    }
}
