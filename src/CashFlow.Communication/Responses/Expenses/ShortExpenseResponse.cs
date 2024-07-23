namespace CashFlow.Communication.Responses.Expenses;

/// <summary>
/// Represents a summarized view of an expense.
/// </summary>
public class ShortExpenseResponse
{
    /// <summary>
    /// Represents the name or title of the expense.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Provides additional details about the expense.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Specifies the monetary value of the expense.
    /// </summary>
    public decimal Amount { get; set; }
}
