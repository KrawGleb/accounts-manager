using iLearning.AccountsManager.Application.Accounts.Commands.Delete;
using iLearning.AccountsManager.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace iLearning.AccountsManager.Application.Accounts.Handlers.CommandHandlers;

public class DeleteCommandHandler : IRequestHandler<DeleteCommand>
{
    private readonly UserManager<Account> _userManager;

    public DeleteCommandHandler(UserManager<Account> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id);

        if (user is not null)
        {
            await _userManager.DeleteAsync(user);
        }

        return Unit.Value;
    }
}
