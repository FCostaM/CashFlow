namespace CashFlow.Communication.Responses.Expenses;

/// <summary>
/// Represents the response containing a list of expenses.
/// </summary>
public class GetExpensesResponse
{
    /// <summary>
    /// Holds a list of <see cref="ShortExpenseResponse"/> objects. 
    /// Each <see cref="ShortExpenseResponse"/> provides a summarized view of an expense.
    /// </summary>
    public List<ShortExpenseResponse> Expenses { get; set; } = [];
}
