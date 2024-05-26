using CashFlow.Application.Validators;
using CashFlow.Communication.Requests;

namespace Validators.Tests.Expenses;

public class ExpenseRegisterValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new ExpenseRegisterValidator();
        var request = new ExpenseRegisterRequest()
        {
            Title = "Test",
            Description = "Test",
            Amount = 1,
            Date = DateTime.Now.AddDays(-1),
            PaymentType = CashFlow.Communication.Enums.PaymentType.Cash
        };

        //Act
        var result = validator.Validate(request);

        //Assert
        Assert.True(result.IsValid);
    }
}
