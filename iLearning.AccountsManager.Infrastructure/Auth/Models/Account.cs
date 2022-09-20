﻿using iLearning.AccountsManager.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace iLearning.AccountsManager.Infrastructure.Auth.Models;

public class Account : IdentityUser
{
    public AccountState State { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime LastLoginDate { get; set; }
}