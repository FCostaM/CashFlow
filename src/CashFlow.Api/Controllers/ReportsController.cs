using CashFlow.Application.Interfaces.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        /// <summary>
        /// Receives a request to generate an Excel report of expenses for a given month.
        /// </summary>
        /// <param name="monthReference">The reference month for which to generate the report.</param>
        /// <param name="useCase">The use case for generating the Excel report.</param>
        /// <returns>A response that contains the generated Excel report or a no content status if no data is available.</returns>
        [HttpGet("excel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetExcelReport([FromHeader] DateTime monthReference, [FromServices] IGenerateExpensesReportExcelUseCase useCase)
        {
            byte[] reportData = await useCase.Execute(monthReference);

            if (reportData.Length > 0)
            {
                return File(reportData, MediaTypeNames.Application.Octet, "report.xlsx");
            }
            else
            {
                return NoContent();
            }
        }
    }
}
