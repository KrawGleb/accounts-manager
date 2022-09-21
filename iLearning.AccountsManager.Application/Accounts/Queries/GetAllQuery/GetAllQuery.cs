using iLearning.AccountsManager.Domain.Models;
using MediatR;

namespace iLearning.AccountsManager.Application.Accounts.Queries.GetAllQuery;

public class GetAllQuery : IRequest<IEnumerable<Account>>
{ }
