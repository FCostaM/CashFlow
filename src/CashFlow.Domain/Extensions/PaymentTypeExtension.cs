using CashFlow.Domain.Enums;
using CashFlow.Domain.Resources.PaymentTypeResource;

namespace CashFlow.Domain.Extensions;

/// <summary>
/// Provides extension methods for converting <see cref="PaymentType"/> enums to their corresponding string representations.
/// </summary>
public static class PaymentTypeExtension
{
    /// <summary>
    /// Converts a <see cref="PaymentType"/> enum to its corresponding string representation.
    /// </summary>
    /// <param name="type">The payment type to convert.</param>
    /// <returns>The string representation of the payment type.</returns>
    public static string PaymentTypeToString(this PaymentType type)
    {
        return type switch
        {
            PaymentType.Cash => PaymentTypeResource.CASH,
            PaymentType.CreditCard => PaymentTypeResource.CREDIT_CARD,
            PaymentType.DebitCard => PaymentTypeResource.DEBIT_CARD,
            PaymentType.BankTransfer => PaymentTypeResource.BANK_TRANSFER,
            PaymentType.Pix => PaymentTypeResource.PIX,
            _ => string.Empty
        };
    }
}
