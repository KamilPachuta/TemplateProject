using Domain.Accounts.ValueObjects;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Domain.Accounts;

public class Account : AggregateRoot
{
    public AccountEmail Email { get; }
    public AccountPasswordHash PasswordHash { get; private set; }
    public AccountRole Role { get; }
    public bool Approved { get; private set; }

    private Account() //Provided for EF core
    {
    }
    
    internal Account(Guid id, AccountEmail email, string password, AccountRole role, IPasswordHasher<Account> passwordHasher)
        : base(id)
    {
        Email = email;
        PasswordHash = new AccountPasswordHash(password, this, passwordHasher);
        Role = role;
        Approved = false;
        
        //RaiseDomainEvent();
    }
    
    public Result VerifyPassword(string password, IPasswordHasher<Account> passwordHasher)
    {
        var result = passwordHasher.VerifyHashedPassword(this, PasswordHash.Value, password);

        if (result is PasswordVerificationResult.Failed)
        {
            return Result.Failure(AccountErrors.InvalidPassword);
        }

        //RaiseDomainEvent(new AccountLoggedInDomainEvent(DateTime.UtcNow, this));

        return Result.Success();
    }
    
    public Result ChangePassword(string password, string newPassword, IPasswordHasher<Account> passwordHasher)
    {
        var verificationResult = VerifyPassword(password, passwordHasher);
        
        if (verificationResult.IsFailure)
        {
            return verificationResult;
        }
        
        var newPasswordHash = new AccountPasswordHash(newPassword, this, passwordHasher);
        
        PasswordHash = newPasswordHash;
        
        //RaiseDomainEvent(new PasswordChangedDomainEvent(DateTime.UtcNow, this));
        
        return Result.Success();
    }
    
    //VerifyAccount
}