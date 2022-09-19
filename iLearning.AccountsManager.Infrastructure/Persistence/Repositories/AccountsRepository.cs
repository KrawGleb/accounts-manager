using iLearning.AccountsManager.Domain.Entities;
using iLearning.AccountsManager.Infrastructure.Persistence.Repositories.Interfaces;

namespace iLearning.AccountsManager.Infrastructure.Persistence.Repositories;

public class AccountsRepository : EFRepository<Account>, IAccountsRepository
{
    public AccountsRepository(ApplicationDbContext context) 
        : base(context)
    { }
}
