using iLearning.AccountsManager.Domain.Models;
using MediatR;

namespace iLearning.AccountsManager.Application.Authentication.Commands.Register;

public class RegisterCommand : IRequest<Account>
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}
