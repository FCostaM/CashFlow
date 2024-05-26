using CashFlow.Application.Validators;
using CommonTestUtilities.Requests;

namespace Validators.Tests.Expenses;

public class ExpenseRegisterValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new ExpenseRegisterValidator();
        var request = ExpenseRegisterRequestBuilder.Build();

        //Act
        var result = validator.Validate(request);

        //Assert
        Assert.True(result.IsValid);
    }
}
