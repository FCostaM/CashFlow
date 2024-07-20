using CashFlow.Application.Interfaces.Reports;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Extensions;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Domain.Resources.ExpenseResource;
using CashFlow.Domain.Resources.ReportResource;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CashFlow.Application.UseCases.Reports;

/// <summary>
/// Use case for generating an PDF report of expenses for a given month and year.
/// </summary>
public class GenerateExpensesReportPdfUseCase : IGenerateExpensesReportPdfUseCase
{
    /// <summary>
    /// Represents the repository for read-only operations on expenses.
    /// </summary>
    private readonly IExpenseReadOnlyRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenerateExpensesReportPdfUseCase"/> class with the specified repository.
    /// </summary>
    /// <param name="repository">The expense read-only repository.</param>
    public GenerateExpensesReportPdfUseCase(IExpenseReadOnlyRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Generates an PDF report of expenses for the specified month and year.
    /// </summary>
    /// <param name="monthReference">The month to generate the report for.</param>
    /// <returns>A task that represents the asynchronous operation, containing the generated PDF file as a byte array.</returns>
    public async Task<byte[]> Execute(DateTime monthReference)
    {
        var startDate = new DateTime(year: monthReference.Year, month: monthReference.Month, day: 1).Date;

        var daysInMonth = DateTime.DaysInMonth(year: monthReference.Year, month: monthReference.Month);
        var endDate = new DateTime(year: monthReference.Year, month: monthReference.Month, day: daysInMonth, hour: 23, minute: 59, second: 59);

        var expenses = await _repository.FilterExpenseByDate(startDate, endDate);

        if (expenses.Count > 0)
        {
            return CreateDocument(monthReference, expenses);
        }
        else
        {
            return [];
        }
    }

    /// <summary>
    /// Creates the PDF document with the expenses data registered for the referenced month.
    /// </summary>
    /// <param name="monthReference">The month reference for the report.</param>
    /// <param name="expenses">List of expenses registered for the referenced month.</param>
    /// <returns>The generated PDF document as a byte array.</returns>
    private byte[] CreateDocument(DateTime monthReference, List<Expense> expenses)
    {
        return Document.Create(document =>
        {
            document.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(11).FontFamily(Fonts.ComicSans));

                page.Content()
                    .Element(content => ComposeDocumentContent(content, monthReference, expenses));

                page.Footer().Element(ComposeDocumentFooter);
            });
        }).GeneratePdf();
    }

    /// <summary>
    /// Composes the content section of the PDF document.
    /// </summary>
    /// <param name="container">Layout structure of the document.</param>
    /// <param name="monthReference">The month reference for the report.</param>
    /// <param name="expenses">List of expenses registered for the referenced month.</param>
    private void ComposeDocumentContent(IContainer container, DateTime monthReference, List<Expense> expenses)
    {
        container
            .PaddingTop(30)
            .Column(column =>
            {
                column.Spacing(45);

                column.Item().Column(column =>
                {
                    column.Spacing(10);

                    column.Item()
                        .Text(string.Format(ReportResource.TOTAL_SPENT_IN, monthReference.ToString("Y")))
                        .FontSize(14);

                    var totalExpenses = expenses.Sum(ex => ex.Amount);
                    column.Item().Text($"R$ {totalExpenses}").Bold().FontSize(40).LetterSpacing(0.05f);
                });

                foreach (var item in expenses)
                {
                    column.Item().Element(t => ComposeExpenseTable(t, item));
                }
            });
    }

    /// <summary>
    /// Composes the table for each expense registered for the referenced month.
    /// </summary>
    /// <param name="container">Layout structure of the document.</param>
    /// <param name="expense">Expense to include in the table.</param>
    private void ComposeExpenseTable(IContainer container, Expense expense)
    {
        container.Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                columns.RelativeColumn(80);
                columns.RelativeColumn(20);
                columns.RelativeColumn(30);
                columns.RelativeColumn(40);
            });

            table.Header(header =>
            {
                header.Cell()
                    .ColumnSpan(3)
                    .Background(Colors.Red.Lighten3)
                    .PaddingHorizontal(15)
                    .PaddingVertical(5)
                    .Text(expense.Title)
                    .LetterSpacing(0.1f)
                    .Black();

                header.Cell()
                    .Background(Colors.Red.Medium)
                    .PaddingHorizontal(15)
                    .AlignRight()
                    .AlignMiddle()
                    .Text(ExpenseResource.AMOUNT)
                    .Black()
                    .FontColor(Colors.White);
            });

            table.Cell()
                .Background(Colors.Green.Lighten4)
                .AlignMiddle()
                .PaddingHorizontal(15)
                .PaddingVertical(5)
                .Text(expense.Date.ToString("D"));

            table.Cell()
                .Background(Colors.Green.Lighten4)
                .AlignMiddle()
                .AlignCenter()
                .Text(expense.Date.ToString("t"));

            table.Cell()
                .Background(Colors.Green.Lighten4)
                .PaddingVertical(5)
                .AlignCenter()
                .AlignMiddle()
                .Text(expense.PaymentType.PaymentTypeToString());

            table.Cell()
                .RowSpan(2)
                .AlignCenter()
                .AlignMiddle()
                .Text($"- R$ {expense.Amount:0.00}");

            if (string.IsNullOrWhiteSpace(expense.Description) == false)
            {
                table.Cell()
                    .ColumnSpan(3)
                    .Background(Colors.Green.Lighten5)
                    .PaddingHorizontal(15)
                    .PaddingVertical(5)
                    .Text(expense.Description)
                    .FontSize(10)
                    .FontColor(Colors.Grey.Darken4);
            }
        });
    }

    /// <summary>
    /// Composes the footer section of the PDF document.
    /// </summary>
    /// <param name="container">Layout structure of the document.</param>
    private void ComposeDocumentFooter(IContainer container)
    {
        container
            .AlignCenter()
            .Text(x =>
            {
                x.Span($"{ReportResource.PAGE} ");
                x.CurrentPageNumber();
            });
    }
}
