using iLearning.AccountsManager.API.Hubs;
using iLearning.AccountsManager.Application.Authentication.Commands.Login;
using iLearning.AccountsManager.Application.Authentication.Commands.Register;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace iLearning.AccountsManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ApiControllerBase
{
    private readonly IHubContext<AccountsHub> _hub;

    public AuthController(IHubContext<AccountsHub> hub)
    {
        _hub = hub;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command)
    {

        var result = await Mediator.Send(command);
        await _hub.Clients.All.SendAsync("NewAccount");

        return Ok(result);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}
