using System.ComponentModel.DataAnnotations;

namespace iLearning.AccountsManager.Domain.Models;

public class RegistrationRequestModel
{
    [Required]
    public string? Name { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }
}
