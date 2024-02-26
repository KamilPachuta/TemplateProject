using Domain.Accounts.Enums;
using Domain.Accounts.Exceptions;


namespace Domain.Accounts.ValueObjects;

public record AccountRole
{
    public Role Value { get; }

    public AccountRole(Role value)
    {
        if (Enum.IsDefined(value))
        {
            throw new RoleNotDefinedException(value);
        }
        
        Value = value;
    }

    public static implicit operator Role(AccountRole value)
        => value.Value;
    
    public static implicit operator AccountRole(Role value)
        => new(value);
}