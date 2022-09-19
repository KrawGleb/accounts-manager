using iLearning.AccountsManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace iLearning.AccountsManager.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{ }

	public DbSet<Account> Accounts { get; set; }
}
