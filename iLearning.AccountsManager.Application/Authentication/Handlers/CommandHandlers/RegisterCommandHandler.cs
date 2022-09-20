using iLearning.AccountsManager.Application.Authentication.Commands.Register;
using iLearning.AccountsManager.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace iLearning.AccountsManager.Application.Authentication.Handlers.CommandHandlers;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Account>
{
    private readonly UserManager<Account> _userManager;

    public RegisterCommandHandler(UserManager<Account> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Account> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is not null)
        {
            // ToDo: Custom exception
            throw new InvalidOperationException();
        }

        var account = new Account()
        {
            Name = request.Name,
            UserName = request.Email,
            Email = request.Email,
            RegistrationDate = DateTime.Now,
            LastLoginDate = DateTime.Now
        };

        var result = await _userManager.CreateAsync(account, request.Password);

        return account;
    }
}
