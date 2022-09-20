using iLearning.AccountsManager.API.Hubs;
using iLearning.AccountsManager.Application.Authentication.Commands.Login;
using iLearning.AccountsManager.Application.Authentication.Commands.Register;
using iLearning.AccountsManager.Domain.Enums;
using iLearning.AccountsManager.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        try
        {
            var result = await Mediator.Send(command);
            await _hub.Clients.All.SendAsync("NewAccount");
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        try
        {
            return Ok(await Mediator.Send(command));
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
}
