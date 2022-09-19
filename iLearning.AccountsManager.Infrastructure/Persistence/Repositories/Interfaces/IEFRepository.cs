using iLearning.AccountsManager.Domain.Entities.Interfaces;

namespace iLearning.AccountsManager.Infrastructure.Persistence.Repositories.Interfaces;

public interface IEFRepository<T> 
    where T : class, IEntity, new()
{
    Task AddAsync(T entity);
}