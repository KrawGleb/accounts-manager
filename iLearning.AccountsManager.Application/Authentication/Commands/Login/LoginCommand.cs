using iLearning.AccountsManager.Domain.Models;
using MediatR;

namespace iLearning.AccountsManager.Application.Authentication.Commands.Login;

public class LoginCommand : IRequest<LoginResult>
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}
