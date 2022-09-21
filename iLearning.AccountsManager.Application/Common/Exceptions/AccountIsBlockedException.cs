namespace iLearning.AccountsManager.Application.Common.Exceptions;

public class AccountIsBlockedException : Exception, ICustomException
{
    public AccountIsBlockedException(string? message)
        : base(message)
    { }

    public AccountIsBlockedException(string? message, Exception? innerException)
        : base(message, innerException)
    { }

    public AccountIsBlockedException()
        : base("This account is blocked.")
    { }
}
