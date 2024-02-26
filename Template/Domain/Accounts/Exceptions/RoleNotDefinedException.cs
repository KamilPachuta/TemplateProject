using Domain.Accounts.Enums;
using Domain.Shared;

namespace Domain.Accounts.Exceptions;

internal sealed class RoleNotDefinedException : ValueObjectException
{
    public Role Role { get; }

    public RoleNotDefinedException(Role role)
        : base($"Role: '{role}' is not defined.")
    {
        Role = role;
    }
}