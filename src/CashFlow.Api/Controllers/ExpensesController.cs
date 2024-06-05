using CashFlow.Application.Interfaces;
using CashFlow.Application.UseCases.Expenses;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.CustomExceptions;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register(
        [FromServices] IExpenseRegisterUseCase useCase,
        [FromBody] ExpenseRegisterRequest request)
    {
        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
