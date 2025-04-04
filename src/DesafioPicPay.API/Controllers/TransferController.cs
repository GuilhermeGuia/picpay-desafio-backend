using DesafioPicPay.Application.Services.Transfer;
using DesafioPicPay.Application.Services.Transfer.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPicPay.API.Controllers;

[Route("[controller]")]
[ApiController]
public class TransferController : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(TransferInput), StatusCodes.Status201Created)]
    public async Task<IActionResult> Transfer(
    [FromServices] ITransferAppService service,
    [FromBody] TransferInput input
)
    {
        var response = await service.Transfer(input);

        return Created(string.Empty, response);
    }
}
