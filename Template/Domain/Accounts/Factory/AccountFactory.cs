using Domain.Accounts.Enums;
using Domain.Accounts.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace Domain.Accounts.Factory;

internal sealed class AccountFactory : IAccountFactory
{
    public Account CreateAdmin(AccountEmail email, string password, IPasswordHasher<Account> passwordHasher)
        => new Account(Guid.NewGuid(), email, password, Role.Admin, passwordHasher);
    public Account CreateModerator(AccountEmail email, string password, IPasswordHasher<Account> passwordHasher)
        => new Account(Guid.NewGuid(), email, password, Role.Moderator, passwordHasher);
    
}