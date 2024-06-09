namespace CashFlow.Communication.Responses;

public class GetExpensesResponse
{
    public List<ShortExpenseResponse> Expenses { get; set; } = [];
}
