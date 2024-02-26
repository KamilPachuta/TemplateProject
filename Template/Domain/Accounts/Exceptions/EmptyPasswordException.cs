using Domain.Shared;

namespace Domain.Accounts.Exceptions;



internal sealed class EmptyPasswordException : ValueObjectException
{
    public EmptyPasswordException() 
        : base("Password cannot be empty.")
    {
    }
}