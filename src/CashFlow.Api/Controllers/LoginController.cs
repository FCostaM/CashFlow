using CashFlow.Application.Interfaces.Login;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    /// <summary>
    /// Receives a request to login from a user.
    /// </summary>
    /// <param name="request">The login request containing user credentials.</param>
    /// <param name="useCase">The use case to execute the login logic.</param>
    /// <returns>The response containing the user details if successful, or an error response if unauthorized.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(UserRegisterRequest), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, [FromServices] ILoginUseCase useCase)
    {
        var response = await useCase.Execute(request);

        return Ok(response);
    }
}
