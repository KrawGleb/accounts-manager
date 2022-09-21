using MediatR;

namespace iLearning.AccountsManager.Application.Accounts.Commands.Unblock;

public class UnblockCommand : IRequest
{
    public string? Id { get; set; }
}
