using MediatR;

namespace iLearning.AccountsManager.Application.Accounts.Commands.Delete;

public class DeleteCommand : IRequest
{
    public string? Id { get; set; }
}
