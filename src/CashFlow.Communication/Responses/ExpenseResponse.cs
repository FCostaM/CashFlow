using CashFlow.Communication.Enums;

namespace CashFlow.Communication.Responses;

/// <summary>
/// Represents the response entity of an expense.
/// </summary>
public class ExpenseResponse
{
    /// <summary>
    /// Represents a unique identifier for each expense.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Represents the name or title of the expense.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Provides additional details about the expense.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Indicates the date and timewhen the expense was incurred.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Specifies the monetary value of the expense.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Represents the payment method used for the expense.
    /// </summary>
    public PaymentType PaymentType { get; set; }
}
