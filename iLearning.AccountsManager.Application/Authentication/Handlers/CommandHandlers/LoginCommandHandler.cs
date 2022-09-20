using iLearning.AccountsManager.Application.Authentication.Commands.Login;
using iLearning.AccountsManager.Domain.Enums;
using iLearning.AccountsManager.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace iLearning.AccountsManager.Application.Authentication.Handlers.CommandHandlers;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
{
    private readonly UserManager<Account> _userManager;
    private readonly IConfiguration _configuration;

    public LoginCommandHandler(
        UserManager<Account> userManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        var passwordIsValid = await _userManager.CheckPasswordAsync(user, request.Password);

        if (user is null || !passwordIsValid)
        {
            // ToDo: Custom exception 
            throw new InvalidOperationException();
        }

        if (user.State == AccountState.Blocked)
        {
            // ToDo: Custom exception
            throw new InvalidOperationException();
        }

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

        return new LoginResult
        {
            Token = token,
            Id = user.Id
        };
    }
}
