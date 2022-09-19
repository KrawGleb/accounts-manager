using iLearning.AccountsManager.Domain.Entities.Interfaces;
using iLearning.AccountsManager.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace iLearning.AccountsManager.Infrastructure.Persistence.Repositories;

public class EFRepository<T> : IEFRepository<T> 
	where T : class, IEntity, new()
{
	private readonly ApplicationDbContext _context;
	private readonly DbSet<T> _table;

	public EFRepository(ApplicationDbContext context)
	{
		_context = context;
		_table = context.Set<T>();
	}

	public virtual async Task AddAsync(T entity)
	{
		await _table.AddAsync(entity);
		await _context.SaveChangesAsync();
	}
}
