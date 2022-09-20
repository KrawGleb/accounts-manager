using iLearning.AccountsManager.API.Hubs;
using iLearning.AccountsManager.Domain.Enums;
using iLearning.AccountsManager.Domain.Models;
using iLearning.AccountsManager.Infrastructure.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace iLearning.AccountsManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AccountsController : ControllerBase
{
    private readonly AuthenticationDbContext _context;
    private readonly UserManager<Account> _userManager;
    private readonly IHubContext<AccountsHub> _hub;

    public AccountsController(
        AuthenticationDbContext context,
        UserManager<Account> userManager,
        IHubContext<AccountsHub> hub)
    {
        _context = context;
        _userManager = userManager;
        _hub = hub;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Accounts.ToListAsync());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById([FromRoute] string id)
    {
        var user =  await _userManager.FindByIdAsync(id);

        if (user is not null)
        {
            await _userManager.DeleteAsync(user);
        }

        await _hub.Clients.All.SendAsync("AccountDeleted", id);

        return Ok();
    }

    [HttpPatch("block/{id}")]
    public async Task<IActionResult> BlockById([FromRoute] string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user is not null)
        {
            user.State = AccountState.Blocked;
            await _userManager.UpdateAsync(user);
        }

        await _hub.Clients.All.SendAsync("AccountBlocked", id);

        return Ok();
    }

    [HttpPatch("unblock/{id}")]
    public async Task<IActionResult> UnblockById([FromRoute] string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user is not null)
        {
            user.State = AccountState.Active;
            await _userManager.UpdateAsync(user);
        }

        await _hub.Clients.All.SendAsync("AccountUnblocked", id);

        return Ok();
    }
}
