using Domain.Shared;

namespace Domain.Accounts.Exceptions;


internal sealed class EmptyPasswordHashException : ValueObjectException
{
    public EmptyPasswordHashException() 
        : base("PasswordHash cannot be empty.")
    {
    }
}