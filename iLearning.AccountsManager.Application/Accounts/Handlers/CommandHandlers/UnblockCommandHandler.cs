using iLearning.AccountsManager.Application.Accounts.Commands.Unblock;
using iLearning.AccountsManager.Domain.Enums;
using iLearning.AccountsManager.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace iLearning.AccountsManager.Application.Accounts.Handlers.CommandHandlers;

public class UnblockCommandHandler : IRequestHandler<UnblockCommand>
{
    private readonly UserManager<Account> _userManager;

    public UnblockCommandHandler(UserManager<Account> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(UnblockCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id);

        if (user is not null)
        {
            user.State = AccountState.Active;
            await _userManager.UpdateAsync(user);
        }

        return Unit.Value;
    }
}
