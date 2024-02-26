using Domain.Shared;

namespace Domain.Accounts.Exceptions;

internal sealed class PasswordLengthExceededException : ValueObjectException
{
    public string Password { get; }

    public PasswordLengthExceededException(string password) 
        : base($"Password: '{password}' is too long. The password cannot exceed 50 characters.")
    {
        Password = password;
    }
}