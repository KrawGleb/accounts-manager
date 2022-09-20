using iLearning.AccountsManager.Domain.Enums;
using iLearning.AccountsManager.Infrastructure.Auth;
using iLearning.AccountsManager.Infrastructure.Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace iLearning.AccountsManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AccountsController : ControllerBase
{
    private readonly AuthenticationDbContext _context;
    private readonly UserManager<Account> _userManager;

    public AccountsController(
        AuthenticationDbContext context,
        UserManager<Account> userManager)
    {
        _context = context;
        _userManager = userManager;
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

        return Ok();
    }
}
