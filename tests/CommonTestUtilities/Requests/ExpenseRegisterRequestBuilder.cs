using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests;

public class ExpenseRegisterRequestBuilder
{
    public static ExpenseRegisterRequest Build()
    {
        return new Faker<ExpenseRegisterRequest>()
            .RuleFor(r => r.Title, f => f.Commerce.ProductName())
            .RuleFor(r => r.Description, f => f.Commerce.ProductDescription())
            .RuleFor(r => r.Date, f => f.Date.Past())
            .RuleFor(r => r.Amount, f => f.Random.Decimal(min: 1, max: 1000))
            .RuleFor(r => r.PaymentType, f => f.PickRandom<PaymentType>());
    }
}
