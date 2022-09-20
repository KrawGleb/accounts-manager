using iLearning.AccountsManager.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace iLearning.AccountsManager.Domain.Models;

public class Account : IdentityUser
{
    public string? Name { get; set; }
    public AccountState State { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime LastLoginDate { get; set; }
}
