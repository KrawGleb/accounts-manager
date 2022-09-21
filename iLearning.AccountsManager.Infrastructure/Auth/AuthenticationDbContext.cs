using iLearning.AccountsManager.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iLearning.AccountsManager.Infrastructure.Auth;

public class AuthenticationDbContext : IdentityDbContext
{
	public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
		: base(options)
	{ }

	public DbSet<Account> Accounts { get; set; }
}
