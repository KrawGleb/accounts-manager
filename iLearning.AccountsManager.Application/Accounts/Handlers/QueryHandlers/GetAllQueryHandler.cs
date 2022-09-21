using iLearning.AccountsManager.Application.Accounts.Queries.GetAllQuery;
using iLearning.AccountsManager.Domain.Models;
using iLearning.AccountsManager.Infrastructure.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace iLearning.AccountsManager.Application.Accounts.Handlers.QueryHandlers;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<Account>>
{
    private readonly AuthenticationDbContext _context;

    public GetAllQueryHandler(AuthenticationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Account>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return await _context.Accounts.ToListAsync(cancellationToken);
    }
}
