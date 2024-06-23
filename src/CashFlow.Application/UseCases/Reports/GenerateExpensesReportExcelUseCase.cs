using CashFlow.Application.Interfaces.Reports;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Extensions;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Domain.Resources.ExpenseResource;
using CashFlow.Domain.Resources.PaymentTypeResource;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Reports;

/// <summary>
/// Use case for generating an Excel report of expenses for a given month.
/// </summary>
public class GenerateExpensesReportExcelUseCase : IGenerateExpensesReportExcelUseCase
{
    /// <summary>
    /// Represents the repository for read-only operations on expenses.
    /// </summary>
    private readonly IExpenseReadOnlyRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenerateExpensesReportExcelUseCase"/> class with the specified repository.
    /// </summary>
    /// <param name="repository">The expense read-only repository.</param>
    public GenerateExpensesReportExcelUseCase(IExpenseReadOnlyRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Generates an Excel report of expenses for the specified month.
    /// </summary>
    /// <param name="monthReference">The month to generate the report for.</param>
    /// <returns>A task that represents the asynchronous operation, containing the generated Excel file as a byte array.</returns>
    public async Task<byte[]> Execute(DateTime monthReference)
    {
        var startDate = new DateTime(year: monthReference.Year, month: monthReference.Month, day: 1).Date;

        var daysInMonth = DateTime.DaysInMonth(year: monthReference.Year, month: monthReference.Month);
        var endDate = new DateTime(year: monthReference.Year, month: monthReference.Month, day: daysInMonth, hour: 23, minute: 59, second: 59);

        var expenses = await _repository.FilterExpenseByDate(startDate, endDate);

        if (expenses.Count == 0)
        {
            return [];
        }
        else
        {
            using var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add(monthReference.ToString("Y"));

            InsertHeaderInExcelFile(worksheet);

            var raw = 2;
            foreach (var expense in expenses)
            {
                worksheet.Cell($"A{raw}").Value = expense.Title;
                worksheet.Cell($"B{raw}").Value = expense.Date;
                worksheet.Cell($"C{raw}").Value = expense.PaymentType.PaymentTypeToString();

                worksheet.Cell($"D{raw}").Value = expense.Amount;
                worksheet.Cell($"D{raw}").Style.NumberFormat.Format = "#,##0.00";

                worksheet.Cell($"E{raw}").Value = expense.Description;

                raw++;
            }

            worksheet.Columns().AdjustToContents();

            var file = new MemoryStream();
            workbook.SaveAs(file);

            return file.ToArray();
        }
    }

    /// <summary>
    /// Inserts the header row into the Excel worksheet.
    /// </summary>
    /// <param name="worksheet">The worksheet to insert the header into.</param>
    private void InsertHeaderInExcelFile(IXLWorksheet worksheet)
    {
        worksheet.Cells("A1:E1").Style.Font.Bold = true;

        worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#F5C2B6");

        worksheet.Cell("A1").Value = ExpenseResource.TITLE;
        worksheet.Cell("B1").Value = ExpenseResource.DATE;
        worksheet.Cell("C1").Value = ExpenseResource.PAYMENT_TYPE;
        worksheet.Cell("D1").Value = ExpenseResource.AMOUNT;
        worksheet.Cell("E1").Value = ExpenseResource.DESCRIPTION;

        worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
        worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
    }
}
