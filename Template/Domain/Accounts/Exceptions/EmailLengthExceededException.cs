using Domain.Shared;

namespace Domain.Accounts.Exceptions;

internal sealed class EmailLengthExceededException : ValueObjectException
{
    public string Email { get; }

    public EmailLengthExceededException(string email) 
        : base($"Email: '{email}' is too long. The email address cannot exceed 50 characters.")
    {
        Email = email;
    }
}