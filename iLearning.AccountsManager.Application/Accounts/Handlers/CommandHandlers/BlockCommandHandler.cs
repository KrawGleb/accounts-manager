using iLearning.AccountsManager.Application.Accounts.Commands.Block;
using iLearning.AccountsManager.Domain.Enums;
using iLearning.AccountsManager.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace iLearning.AccountsManager.Application.Accounts.Handlers.CommandHandlers;

public class BlockCommandHandler : IRequestHandler<BlockCommand>
{
    private readonly UserManager<Account> _userManager;

    public BlockCommandHandler(UserManager<Account> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(BlockCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id);

        if (user is not null)
        {
            user.State = AccountState.Blocked;
            await _userManager.UpdateAsync(user);
        }

        return Unit.Value;
    }
}
