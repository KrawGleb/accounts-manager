using MediatR;

namespace iLearning.AccountsManager.Application.Accounts.Commands.Block;

public class BlockCommand : IRequest
{
    public string? Id { get; set; }
}
