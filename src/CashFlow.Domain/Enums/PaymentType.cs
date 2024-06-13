namespace CashFlow.Domain.Enums;

/// <summary>
/// Represents the possible payment methods that can be used for the expense.
/// </summary>
public enum PaymentType
{
    Cash = 1,
    CreditCard = 2,
    DebitCard = 3,
    BankTransfer = 4,
    Pix = 5
}
