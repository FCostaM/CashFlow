using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities;

/// <summary>
/// Represents an expense entity.
/// </summary>
public class Expense
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

    /// <summary>
    /// Represents the unique identifier of the user related to the expense.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Represents the user related to the expense.
    /// </summary>
    public User User { get; set; } = default!;
}
