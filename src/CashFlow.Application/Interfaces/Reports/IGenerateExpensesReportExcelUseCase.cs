namespace CashFlow.Application.Interfaces.Reports;

/// <summary>
/// Defines the contract for a use case to generate an Excel report of expenses for a given month.
/// </summary>
public interface IGenerateExpensesReportExcelUseCase
{
    /// <summary>
    /// Generates an Excel report of expenses for the specified month.
    /// </summary>
    /// <param name="monthReference">The month to generate the report for.</param>
    /// <returns>A task that represents the asynchronous operation, containing the generated Excel file as a byte array.</returns>
    Task<byte[]> Execute(DateTime monthReference);
}
