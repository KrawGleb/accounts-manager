using iLearning.AccountsManager.API.Hubs;
using iLearning.AccountsManager.Application.Accounts.Commands.Block;
using iLearning.AccountsManager.Application.Accounts.Commands.Delete;
using iLearning.AccountsManager.Application.Accounts.Commands.Unblock;
using iLearning.AccountsManager.Application.Accounts.Queries.GetAllQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace iLearning.AccountsManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AccountsController : ApiControllerBase
{
    private readonly IHubContext<AccountsHub> _hub;

    public AccountsController(IHubContext<AccountsHub> hub)
    {
        _hub = hub;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllQuery()));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById([FromRoute] string id)
    {
        await Mediator.Send(new DeleteCommand { Id = id });
        await _hub.Clients.All.SendAsync("AccountDeleted", id);

        return Ok();
    }

    [HttpPatch("block/{id}")]
    public async Task<IActionResult> BlockById([FromRoute] string id)
    {
        await Mediator.Send(new BlockCommand { Id = id });
        await _hub.Clients.All.SendAsync("AccountBlocked", id);

        return Ok();
    }

    [HttpPatch("unblock/{id}")]
    public async Task<IActionResult> UnblockById([FromRoute] string id)
    {
        await Mediator.Send(new UnblockCommand { Id = id });
        await _hub.Clients.All.SendAsync("AccountUnblocked", id);

        return Ok();
    }
}
