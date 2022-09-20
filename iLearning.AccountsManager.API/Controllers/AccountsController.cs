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

	public AccountsController(AuthenticationDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<IEnumerable<Account>> GetAll()
	{
		return await _context.Accounts.ToListAsync();
	}
}
