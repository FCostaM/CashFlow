using CashFlow.Application.Interfaces;
using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(
        [FromServices] IExpenseRegisterUseCase useCase,
        [FromBody] ExpenseRegisterRequest request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
