using Domain.Shared;

namespace Domain.Accounts.Exceptions;

internal sealed class EmptyEmailException : ValueObjectException
{
    public EmptyEmailException() 
        : base("Email cannot be empty.")
    {
    }
}