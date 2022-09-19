using iLearning.AccountsManager.Domain.Entities.Interfaces;
using iLearning.AccountsManager.Domain.Enums;

namespace iLearning.AccountsManager.Domain.Entities;

public class Account : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public AccountState State { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime LastLoginDate { get; set; }
}
