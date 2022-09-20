using iLearning.AccountsManager.Domain.Models;
using iLearning.AccountsManager.Infrastructure.Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace iLearning.AccountsManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly UserManager<Account> _userManager;
	private readonly SignInManager<Account> _signInManager;

	public AuthController(
		UserManager<Account> userManager,
		SignInManager<Account> signInManager)
	{
		_userManager = userManager;
		_signInManager = signInManager;
	}

	[HttpPost]
	[Route("register")]
	public async Task<IActionResult> Register([FromBody] RegistrationRequestModel registrationRequest)
	{
		var account = new Account()
		{
			UserName = registrationRequest.Name,
			Email = registrationRequest.Email,
		};

		var result = await _userManager.CreateAsync(account, registrationRequest.Password);

		return Ok(result);
	}
}
