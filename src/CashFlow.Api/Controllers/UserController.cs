using CashFlow.Application.Interfaces.Users;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Communication.Responses.Users;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="useCase"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(UserRegisterResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest request, [FromServices] IUserRegisterUseCase useCase)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
