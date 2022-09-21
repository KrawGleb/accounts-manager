namespace iLearning.AccountsManager.Application.Common.Exceptions;

public class InvalidPasswordOrEmailException : Exception, ICustomException
{
    public InvalidPasswordOrEmailException(string? message) 
        : base(message)
    { }

    public InvalidPasswordOrEmailException(string? message, Exception? innerException) 
        : base(message, innerException)
    { }

    public InvalidPasswordOrEmailException()
        : base ("Invalid password or email.")
    { }
}
