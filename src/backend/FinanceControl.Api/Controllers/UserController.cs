using FinanceControl.Communication.Requests;
using FinanceControl.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FinanceControl.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson),StatusCodes.Status201Created)]
    public IActionResult Register(RequestRegisterJson request)
    {
        return Created();
    }
}