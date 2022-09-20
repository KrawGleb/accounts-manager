using iLearning.AccountsManager.Domain.Models;
using iLearning.AccountsManager.Infrastructure.Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace iLearning.AccountsManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<Account> _userManager;
    private readonly SignInManager<Account> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthController(
        UserManager<Account> userManager,
        SignInManager<Account> signInManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationRequestModel registrationRequest)
    {
        var user = await _userManager.FindByEmailAsync(registrationRequest.Email);

        if (user is not null)
        {
            return BadRequest();
        }

        var account = new Account()
        {
            Name = registrationRequest.Name,
            UserName = registrationRequest.Email,
            Email = registrationRequest.Email,
            RegistrationDate = DateTime.Now,
            LastLoginDate = DateTime.Now
        };

        var result = await _userManager.CreateAsync(account, registrationRequest.Password);

        return Ok(result);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestModel loginRequest)
    {
        var user = await _userManager.FindByEmailAsync(loginRequest.Email);

        if (user is not null &&
            await _userManager.CheckPasswordAsync(user, loginRequest.Password))
        {
            user.LastLoginDate = DateTime.Now;

            var key = Encoding.UTF8.GetBytes(_configuration["ApplicationSettings:JWT_Secret"].ToString());

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserID", user.Id),

                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return Ok(new { token });
        }

        return BadRequest();
    }
}
