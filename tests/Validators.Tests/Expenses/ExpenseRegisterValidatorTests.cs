using CashFlow.Application.Validators;
using CashFlow.Communication.Enums;
using CashFlow.Exception.Resources;
using CommonTestUtilities.Requests;
using FluentAssertions;

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
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("         ")]
    [InlineData(null)]
    public void TitleEmptyFailure(string title)
    {
        //Arrange
        var validator = new ExpenseRegisterValidator();
        var request = ExpenseRegisterRequestBuilder.Build();
        request.Title = title;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();

        result.Errors
            .Should()
            .ContainSingle().And
            .Contain(e => e.ErrorMessage.Equals(ErrorMessageResource.TITLE_REQUIRED));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-10)]
    public void AmountInvalidFailure(decimal amount)
    {
        //Arrange
        var validator = new ExpenseRegisterValidator();
        var request = ExpenseRegisterRequestBuilder.Build();
        request.Amount = amount;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();

        result.Errors
            .Should()
            .ContainSingle().And
            .Contain(e => e.ErrorMessage.Equals(ErrorMessageResource.AMOUNT_UNDER_ZERO));
    }

    [Fact]
    public void FutureDateFailure()
    {
        //Arrange
        var validator = new ExpenseRegisterValidator();
        var request = ExpenseRegisterRequestBuilder.Build();
        request.Date = DateTime.UtcNow.AddDays(1);

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();

        result.Errors
            .Should()
            .ContainSingle().And
            .Contain(e => e.ErrorMessage.Equals(ErrorMessageResource.PAST_DATE_EXPENSE));
    }

    [Fact]
    public void PaymentTypeInvalidFailure()
    {
        //Arrange
        var validator = new ExpenseRegisterValidator();
        var request = ExpenseRegisterRequestBuilder.Build();
        request.PaymentType = (PaymentType)700;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();

        result.Errors
            .Should()
            .ContainSingle().And
            .Contain(e => e.ErrorMessage.Equals(ErrorMessageResource.PAYMENT_TYPE_INVALID));
    }
}
