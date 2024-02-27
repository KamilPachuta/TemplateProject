using Domain.Accounts.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace Domain.Accounts.Factory;

public interface IAccountFactory
{
    Account CreateAdmin(AccountEmail email, string password, IPasswordHasher<Account> passwordHasher);
}