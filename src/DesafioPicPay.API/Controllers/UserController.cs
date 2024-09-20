using DesafioPicPay.Application.Services.User;
using DesafioPicPay.Application.Services.User.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPicPay.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(CreateUserInput), StatusCodes.Status201Created)]
    public IActionResult Register(CreateUserInput input)
    {
        var userAppService = new UserAppService();
        var response = userAppService.Create(input);

        return Created(string.Empty, response);
    }
}
