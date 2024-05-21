using CashFlow.Application.UseCases.Expenses;
using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] ExpenseRegisterRequest request)
    {
        var response = new ExpenseRegisterUseCase().Execute(request);
        
        return Created(string.Empty, response);
    }
}
