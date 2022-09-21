namespace iLearning.AccountsManager.Application.Common.Exceptions;

public class AccountExistsException : Exception, ICustomException
{
    public AccountExistsException(string? message)
        : base(message)
    { }

    public AccountExistsException(string? message, Exception? innerException)
        : base(message, innerException)
    { }

    public AccountExistsException()
        : base("Account already exists.")
    { }
}
