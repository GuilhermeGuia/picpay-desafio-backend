using DesafioPicPay.Application.Services.User;
using DesafioPicPay.Application.Services.User.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPicPay.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(UserOutput), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(
        long Id
        , [FromServices] IUserAppService service
    )
    {
        var response = await service.Get(Id);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateUserInput), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IUserAppService service,
        [FromBody] CreateUserInput input
    )
    {
        var response = await service.Create(input);
        return Created(string.Empty, response);
    }

}
