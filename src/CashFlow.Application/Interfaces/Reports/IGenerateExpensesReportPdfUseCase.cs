namespace CashFlow.Application.Interfaces.Reports;

/// <summary>
/// Defines the contract for a use case to generate an PDF report of expenses for a given month and year.
/// </summary>
public interface IGenerateExpensesReportPdfUseCase
{
    /// <summary>
    /// Generates an PDF report of expenses for the specified month and year.
    /// </summary>
    /// <param name="monthReference">The month to generate the report for.</param>
    /// <returns>A task that represents the asynchronous operation, containing the generated PDF file as a byte array.</returns>
    public Task<byte[]> Execute(DateTime monthReference);
}
