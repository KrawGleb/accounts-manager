using iLearning.AccountsManager.Application.Authentication.Commands.Register;
using iLearning.AccountsManager.Application.Common.Exceptions;
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
        var existingAccount = await _userManager.FindByEmailAsync(request.Email);

        if (existingAccount is not null)
        {
            throw new AccountExistsException();
        }

        var account = new Account()
        {
            Name = request.Name,
            UserName = request.Email,
            Email = request.Email,
            RegistrationDate = DateTime.Now,
            LastLoginDate = DateTime.Now
        };

        await _userManager.CreateAsync(account, request.Password);

        return account;
    }
}
